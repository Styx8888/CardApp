using CardApp.Domain.Enums;

namespace CardApp.Domain
{
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);
}
