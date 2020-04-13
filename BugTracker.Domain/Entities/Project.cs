using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; private set; }
    }
}
