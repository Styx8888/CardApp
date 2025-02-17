using CardApp.Application.Services.Interfaces;
using CardApp.Domain.Enums;

namespace CardApp.Application.Services
{
    public class CardActionService : ICardActionService
    {
        public List<CardAction> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet)
        {
            throw new NotImplementedException();
        }
    }
}
