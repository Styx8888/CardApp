using CardApp.Domain;

namespace CardApp.Application.Services.Interfaces
{
    public interface ICardDetailsService
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}
