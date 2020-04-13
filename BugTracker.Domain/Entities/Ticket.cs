using System;

namespace BugTracker.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketStatusId { get; set; }
        public int TicketPriorityId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public TicketType Type { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
