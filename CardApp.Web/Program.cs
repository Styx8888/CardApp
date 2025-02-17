using CardApp.Application.Actions;
using CardApp.Application.Actions.Interfaces;
using CardApp.Application.Services;
using CardApp.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICardActionService, CardActionService>();
builder.Services.AddSingleton<IAllowedActions, AllowedActions>();
builder.Services.AddSingleton<ICardDetailsService, CardDetailsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/card/actions", async (string userId, string cardNumber, ICardDetailsService cardDetailsService, ICardActionService cardActionService) =>
{
    // TODO: add validator here for userId and cardNumber 
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
