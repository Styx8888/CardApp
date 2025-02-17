using CardApp.Application.Actions.Interfaces;
using CardApp.Domain.Enums;

namespace CardApp.Application.Actions
{
    public class AllowedActions : IAllowedActions
    {
        public List<CardAction> GetAllowedActions(CardType cardType)
        {
            return cardType switch
            {
                CardType.Prepaid => [CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13],
                CardType.Debit => [CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13],
                CardType.Credit => [CardAction.Action1, CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13],
                _ => new List<CardAction>(),
            };
        }

        public List<CardAction> GetAllowedActions(CardStatus cardStatus, bool pinSet)
        {
            return cardStatus switch
            {
                CardStatus.Ordered => new List<CardAction>
                {
                    CardAction.Action3, CardAction.Action4, CardAction.Action5, 
                    pinSet ? CardAction.Action6 : CardAction.Action7, 
                    CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13
                },
                CardStatus.Inactive => new List<CardAction>
                    {
                    CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action5,
                    pinSet ? CardAction.Action6 : CardAction.Action7, 
                    CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11,
                    CardAction.Action12, CardAction.Action13
                    },
                CardStatus.Active => new List<CardAction>
                    {
                    CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action5,
                    pinSet ? CardAction.Action6 : CardAction.Action7,
                    CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11,
                    CardAction.Action12, CardAction.Action13
                    },
                CardStatus.Restricted => new List<CardAction>
                    {
                    CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9
                    },
                CardStatus.Blocked => new List<CardAction>
                    {
                    CardAction.Action3, CardAction.Action4, CardAction.Action5, // Always included
                    CardAction.Action8, CardAction.Action9 // Always included
                    }.Concat(pinSet ? [CardAction.Action6, CardAction.Action7] : Enumerable.Empty<CardAction>()).ToList(),
                CardStatus.Expired => new List<CardAction>
                    {
                    CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9
                    },
                CardStatus.Closed => new List<CardAction>
                    {
                    CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9
                    },
                _ => new List<CardAction>() 
            };
        }
    }
}
