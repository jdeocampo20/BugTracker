using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IProjectRepository projectRepository;

        public TicketsController(ITicketRepository ticketRepository,
            IProjectRepository projectRepository)
        {
            this.ticketRepository = ticketRepository;
            this.projectRepository = projectRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var tickets = ticketRepository.AllTickets;
            return View(tickets);
        }

        public IActionResult Create()
        {
            var projects = projectRepository.AllProjects.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            var ctvm = new CreateTicketViewModel
            {
                Ticket = new Ticket(),
                Projects = projects
            };

            return View(ctvm);
        }

        public async Task<IActionResult> Details(int ticketId)
        {
            var ticket = await ticketRepository.GetTicketByIdAsync(ticketId);
            return View(ticket);
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewTicket(CreateTicketViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await ticketRepository.AddTicketAsync(viewModel.Ticket);
            await ticketRepository.CommitAsync();
            return RedirectToAction("Index");
        }
    }
}
