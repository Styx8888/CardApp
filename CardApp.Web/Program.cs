using System.Text.Json.Serialization;
using CardApp.Application.Actions;
using CardApp.Application.Actions.Interfaces;
using CardApp.Application.Services;
using CardApp.Application.Services.Interfaces;
using CardApp.Web.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<UserIdCardRequestValidator>();

builder.Services.AddSingleton<ICardActionService, CardActionService>();
builder.Services.AddSingleton<IAllowedActions, AllowedActions>();
builder.Services.AddSingleton<ICardDetailsService, CardDetailsService>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/card/actions", async (
    string userId,
    string cardNumber,
    ICardDetailsService cardDetailsService,
    ICardActionService cardActionService,
    IValidator<(string userId, string cardNumber)> validator
    ) =>
{
    var validationResult = await validator.ValidateAsync((userId, cardNumber));
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var cardDetails = await cardDetailsService.GetCardDetails(userId, cardNumber);
    if (cardDetails == null)
    {
        return Results.Problem(
            type: "Not Found",
            title: "Card or UserId is wrong",
            detail: "Combination of Card and UserId is wrong",
            statusCode: StatusCodes.Status404NotFound);
    }
    var allowedActions = cardActionService.GetAllowedActions(cardDetails.CardType, cardDetails.CardStatus, cardDetails.IsPinSet);
    return Results.Ok(allowedActions);
})
.WithName("GetAllowedActions")
.WithOpenApi();

app.Run();
