using System;
namespace BugTracker.Domain.Enums
{
    public enum TicketPriority
    {
        Trivial = 1, // Trivial problem with little or no impact on progress.
        Low = 2, // Minor problem or easily worked around.
        Medium = 3, // Has the potential to affect progress.
        High = 4, // Serious problem that could block progress.
        Critical = 5 // Problem blocks progress.
    }
}
