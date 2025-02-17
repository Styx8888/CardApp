using CardApp.Domain.Enums;

namespace CardApp.Application.Actions.Interfaces
{
    public interface IAllowedActions
    {
        List<CardAction> GetAllowedActions(CardType cardType);

        List<CardAction> GetAllowedActions(CardStatus cardStatus, bool pinSet);
    }
}
