using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Project field is required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "The Type field is required")]
        public int TicketTypeId { get; set; }

        [Required]
        public int TicketStatusId { get; set; }

        [Required(ErrorMessage = "The Priority field is required")]
        public int TicketPriorityId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Project Project { get; set; }
        public TicketType Type { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
