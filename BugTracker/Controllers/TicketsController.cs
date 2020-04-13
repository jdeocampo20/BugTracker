using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var tickets = ticketRepository.AllTickets;
            return View(tickets);
        }
    }
}
