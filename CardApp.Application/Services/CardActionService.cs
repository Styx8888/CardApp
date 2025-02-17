using CardApp.Application.Actions.Interfaces;
using CardApp.Application.Services.Interfaces;
using CardApp.Domain.Enums;

namespace CardApp.Application.Services
{
    public class CardActionService : ICardActionService
    {
        private readonly IAllowedActions _allowedActions;

        public CardActionService(IAllowedActions allowedActions) => _allowedActions = allowedActions;

        public List<CardAction> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet)
        {
            var allowedActionsBasedOnCardType = _allowedActions.GetAllowedActions(cardType);
            var allowedActionsBasedOnCardStatusAndPin = _allowedActions.GetAllowedActions(cardStatus, isPinSet);
            return allowedActionsBasedOnCardType.Intersect(allowedActionsBasedOnCardStatusAndPin).ToList();
        }
    }
}
