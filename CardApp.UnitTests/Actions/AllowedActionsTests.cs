using CardApp.Application.Actions;
using CardApp.Domain.Enums;
using Shouldly;

namespace CardApp.UnitTests.Actions
{
    public class AllowedActionsTests
    {
        [Theory]
        [MemberData(nameof(AllowedActionsBasedOnCardTypeData))]
        public void GetAllowedActions_GivenCardType_ReturnsCorrectActions(CardType cardType, List<CardAction> expectedAllowedActions)
        {
            var allowedActions = new AllowedActions();
            var actions = allowedActions.GetAllowedActions(cardType);
            actions.ShouldBe(expectedAllowedActions);
        }

        [Theory]
        [MemberData(nameof(AllowedActionsBasedOnCardStatusAndPinData))]
        public void GetAllowedActions_GivenCardStatusAndPin_ReturnsCorrectActions(CardStatus cardStatus, bool isPinSet, List<CardAction> expectedAllowedActions)
        {
            var allowedActions = new AllowedActions();
            var actions = allowedActions.GetAllowedActions(cardStatus, isPinSet);
            actions.ShouldBe(expectedAllowedActions, true);
        }

        public static IEnumerable<object[]> AllowedActionsBasedOnCardTypeData =>
    new List<object[]>
    {
        new object[] { CardType.Prepaid, GetAllowedActionsWithout(CardAction.Action5) },
        new object[] { CardType.Debit, GetAllowedActionsWithout(CardAction.Action5) },
        new object[] { CardType.Credit, Enum.GetValues(typeof(CardAction)).Cast<CardAction>().ToList() }
    };

        public static IEnumerable<object[]> AllowedActionsBasedOnCardStatusAndPinData =>
    new List<object[]>
    {
        new object[] { CardStatus.Ordered, true, GetAllowedActionsWithout(CardAction.Action1, CardAction.Action2, CardAction.Action7, CardAction.Action11) },
        new object[] { CardStatus.Ordered, false, GetAllowedActionsWithout(CardAction.Action1, CardAction.Action2, CardAction.Action6, CardAction.Action11) },
        new object[] { CardStatus.Inactive, true, GetAllowedActionsWithout(CardAction.Action1, CardAction.Action7) },
        new object[] { CardStatus.Inactive, false, GetAllowedActionsWithout(CardAction.Action1, CardAction.Action6) },
        new object[] { CardStatus.Active, true, GetAllowedActionsWithout(CardAction.Action2, CardAction.Action7) },
        new object[] { CardStatus.Active, false, GetAllowedActionsWithout(CardAction.Action2, CardAction.Action6) },
        new object[] { CardStatus.Restricted, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } },
        new object[] { CardStatus.Restricted, false, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } },
        new object[] { CardStatus.Blocked, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9 } },
        new object[] { CardStatus.Blocked, false, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action8, CardAction.Action9 } },
        new object[] { CardStatus.Expired, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } },
        new object[] { CardStatus.Expired, false, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } },
        new object[] { CardStatus.Closed, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } },
        new object[] { CardStatus.Closed, false, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 } }
    };
    

        private static List<CardAction> GetAllowedActionsWithout(params CardAction[] actionsToRemove)
        {
            var actions = Enum.GetValues(typeof(CardAction)).Cast<CardAction>().ToList();
            actions.RemoveAll(a => actionsToRemove.Contains(a));
            return actions;
        }
    }


}