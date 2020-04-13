using System.Collections.Generic;

namespace BugTracker.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; private set; }
    }
}
