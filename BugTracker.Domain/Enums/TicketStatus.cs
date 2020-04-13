using System;
namespace BugTracker.Domain.Enums
{
    public enum TicketStatus
    {
        ToDo = 1, // The issue has been reported and is waiting for the team to action it.
        Open = 2, // The issue is open and ready for the assignee to start work on it.
        InProgress = 3, // This issue is being actively worked on at the moment by the assignee.
        Resolved = 4, // A resolution has been taken, and it is awaiting verification by reporter. From here, issues are either reopened, or are closed.
        Reopened = 5, // This issue was once resolved, but the resolution was deemed incorrect. From here, issues are either marked assigned or resolved.
        Closed = 6 // The issue is considered finished. The resolution is correct. Issues which are closed can be reopened.
    }
}
