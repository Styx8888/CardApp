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
            actions.ShouldBeEquivalentTo(expectedAllowedActions);
        }

        public static IEnumerable<object[]> AllowedActionsBasedOnCardTypeData =>
    new List<object[]>
    {
        new object[] { CardType.Prepaid, GetAllowedActionsWithout(CardAction.Action5) },
        new object[] { CardType.Debit, GetAllowedActionsWithout(CardAction.Action5) },
        new object[] { CardType.Credit, Enum.GetValues(typeof(CardAction)).Cast<CardAction>().ToList() }
    };

        private static List<CardAction> GetAllowedActionsWithout(CardAction actionToRemove)
        {
            var actions = Enum.GetValues(typeof(CardAction)).Cast<CardAction>().ToList();
            actions.Remove(actionToRemove);
            return actions;
        }
    }
}