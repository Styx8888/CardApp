using CardApp.Domain.Enums;

namespace CardApp.Application.Services.Interfaces
{
    public interface ICardActionService
    {
        List<CardAction> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet);
    }
}
