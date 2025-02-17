using CardApp.Domain.Enums;

namespace CardApp.Application.Actions.Interfaces
{
    public interface IAllowedActions
    {
        List<AllowedActions> GetAllowedActions(CardType cardType);

        List<AllowedActions> GetAllowedActions(CardStatus cardStatus, bool pinSet);
    }
}
