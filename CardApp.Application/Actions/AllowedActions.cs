using CardApp.Application.Actions.Interfaces;
using CardApp.Domain.Enums;

namespace CardApp.Application.Actions
{
    public class AllowedActions : IAllowedActions
    {
        public List<AllowedActions> GetAllowedActions(CardType cardType)
        {
            throw new NotImplementedException();
        }

        public List<AllowedActions> GetAllowedActions(CardStatus cardStatus, bool pinSet)
        {
            throw new NotImplementedException();
        }
    }
}
