using CardApp.Application.Actions.Interfaces;
using CardApp.Domain.Enums;

namespace CardApp.Application.Actions
{
    public class AllowedActions : IAllowedActions
    {
        public List<CardAction> GetAllowedActions(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Prepaid: return new List<CardAction>() { CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 };
                case CardType.Debit: return new List<CardAction>() { CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 };
                case CardType.Credit: return new List<CardAction>() { CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 };
                default: return new List<CardAction>();
            }
        }

        public List<CardAction> GetAllowedActions(CardStatus cardStatus, bool pinSet)
        {
            throw new NotImplementedException();
        }
    }
}
