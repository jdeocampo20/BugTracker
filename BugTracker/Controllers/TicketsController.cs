using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var tickets = await ticketRepository.AllTickets.ToListAsync();
            return View(tickets);
        }

        public async Task<IActionResult> Create()
        {
            var projects = await projectRepository.AllProjects
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

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

        public async Task<IActionResult> Edit(int ticketId)
        {
            var ticket = await ticketRepository.GetTicketByIdAsync(ticketId);

            var projects = await projectRepository.AllProjects
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

            var statuses = await ticketRepository.AllTicketStatuses
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

            var ctvm = new EditTicketViewModel
            {
                Ticket = ticket,
                Projects = projects,
                Statuses = statuses
            };

            return View(ctvm);
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

        [HttpPost]
        public async Task<IActionResult> EditTicket(CreateTicketViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ticketRepository.UpdateTicket(viewModel.Ticket);
            await ticketRepository.CommitAsync();
            return RedirectToAction("Details", new { ticketId = viewModel.Ticket.Id });
        }
    }
}
