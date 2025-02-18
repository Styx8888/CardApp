using CardApp.Domain.Enums;

namespace CardApp.Application.Actions.Interfaces
{
    public interface IAllowedActions
    {
        IEnumerable<CardAction> GetAllowedActions(CardType cardType);

        IEnumerable<CardAction> GetAllowedActions(CardStatus cardStatus, bool pinSet);
    }
}
