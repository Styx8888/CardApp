using CardApp.Application.Services;
using CardApp.Domain.Enums;
using Shouldly;

namespace CardApp.UnitTests.Services
{
    public class CardActionServiceTests
    {
        [Theory]
        [MemberData(nameof(AllowedActionsData))]
        public void GetAllowedActions_GivenAllData_ReturnsCorrectActions(CardType cardType, CardStatus cardStatus, bool isPinSet, List<CardAction> expectedAllowedActions)
        {
            var cardActionsService = new CardActionService();
            var possibleActions = cardActionsService.GetAllowedActions(cardType, cardStatus, isPinSet);
            possibleActions.ShouldBe(expectedAllowedActions, true);
        }


        public static IEnumerable<object[]> AllowedActionsData =>
    new List<object[]>
    {
        new object[] { CardType.Prepaid, CardStatus.Closed, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action9 } },
        new object[] { CardType.Prepaid, CardStatus.Closed, false, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action9 } },
        new object[] { CardType.Credit, CardStatus.Blocked, true, new List<CardAction> { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9 } },
    };
    }
}
