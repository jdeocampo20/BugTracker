using System;
using System.Collections.Generic;
using BugTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.Models
{
    public class CreateTicketViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }
    }
}
