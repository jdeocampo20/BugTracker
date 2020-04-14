using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using Enums = BugTracker.Domain.Enums;

namespace BugTracker.Persistence
{
    public class InMemoryTicketRepository : ITicketRepository
    {
        private readonly IMachineDateTime machineDateTime;
        private readonly IProjectRepository projectRepository;
        public List<Ticket> tickets;
        public List<TicketType> ticketTypes;
        public List<TicketStatus> ticketStatuses;
        public List<TicketPriority> ticketPriorities;

        public InMemoryTicketRepository(IMachineDateTime machineDateTime, IProjectRepository projectRepository)
        {
            ticketTypes = Enum.GetNames(typeof(Enums.TicketType))
                .Select(x => new TicketType
                {
                    Id = (int)Enum.Parse(typeof(Enums.TicketType), x),
                    Name = x
                })
                .ToList();
            ticketStatuses = Enum.GetNames(typeof(Enums.TicketStatus))
                .Select(x => new TicketStatus
                {
                    Id = (int)Enum.Parse(typeof(Enums.TicketStatus), x),
                    Name = x
                })
                .ToList();
            ticketPriorities = Enum.GetNames(typeof(Enums.TicketPriority))
                .Select(x => new TicketPriority
                {
                    Id = (int)Enum.Parse(typeof(Enums.TicketPriority), x),
                    Name = x
                })
                .ToList();

            tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Name = "Missing nav menu",
                    Description = "Link to dashboard page missing in nav",
                    CreatedDate = DateTime.Now,
                    TicketTypeId = (int)Enums.TicketType.Bug,
                    Type = ticketTypes.FirstOrDefault(t => t.Id == (int)Enums.TicketType.Bug),
                    TicketStatusId = (int)Enums.TicketStatus.ToDo,
                    Status = ticketStatuses.FirstOrDefault(t => t.Id == (int)Enums.TicketStatus.ToDo),
                    TicketPriorityId = (int)Enums.TicketPriority.Medium,
                    Priority = ticketPriorities.FirstOrDefault(t => t.Id == (int)Enums.TicketPriority.Medium),
                    ProjectId = 1,
                    Project = new Project
                    {
                        Id = 1,
                        Name = "Project 1"
                    }
                },
                new Ticket
                {
                    Id = 2,
                    Name = "Add blog page",
                    Description = "Create new page for blog posts",
                    CreatedDate = DateTime.Now,
                    TicketTypeId = (int)Enums.TicketType.Bug,
                    Type = ticketTypes.FirstOrDefault(t => t.Id == (int)Enums.TicketType.Bug),
                    TicketStatusId = (int)Enums.TicketStatus.ToDo,
                    Status = ticketStatuses.FirstOrDefault(t => t.Id == (int)Enums.TicketStatus.ToDo),
                    TicketPriorityId = (int)Enums.TicketPriority.Medium,
                    Priority = ticketPriorities.FirstOrDefault(t => t.Id == (int)Enums.TicketPriority.Medium),
                    ProjectId = 2,
                    Project = new Project
                    {
                        Id = 2,
                        Name = "Project 2"
                    }
                }
            };
            this.machineDateTime = machineDateTime;
            this.projectRepository = projectRepository;
        }

        public IQueryable<TicketType> AllTicketTypes => ticketTypes.AsQueryable();

        public IQueryable<TicketStatus> AllTicketStatuses => ticketStatuses.AsQueryable();

        public IQueryable<TicketPriority> AllTicketPriorities => ticketPriorities.AsQueryable();

        public IQueryable<Ticket> AllTickets => tickets.AsQueryable();

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            await Task.Run(async () =>
            {
                ticket.Id = tickets.Max(t => t.Id) + 1;
                ticket.CreatedDate = machineDateTime.Now;
                ticket.ModifiedDate = machineDateTime.Now;
                ticket.TicketStatusId = (int)Enums.TicketStatus.ToDo;
                ticket.Project = await projectRepository.GetProjectByIdAsync(ticket.ProjectId);
                ticket.Type = AllTicketTypes.FirstOrDefault(t => t.Id == ticket.TicketTypeId);
                ticket.Priority = AllTicketPriorities.FirstOrDefault(t => t.Id == ticket.TicketPriorityId);
                ticket.Status = AllTicketStatuses.FirstOrDefault(t => t.Id == (int)Enums.TicketStatus.ToDo);
            });
            tickets.Add(ticket);
            return ticket;
        }

        public Task<int> CommitAsync()
        {
            return Task.Run(() => 0);
        }

        public async Task<Ticket> DeleteTicketAsync(int ticketId)
        {
            var ticket = await Task.Run(() => tickets.FirstOrDefault(t => t.Id == ticketId));
            if(ticket != null)
            {
                tickets.Remove(ticket);
            }
            return ticket;
        }

        public Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return Task.Run(() => tickets.SingleOrDefault(t => t.Id == ticketId));
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            var ticketToUpdate = tickets.SingleOrDefault(t => t.Id == ticket.Id);
            if(ticketToUpdate != null)
            {
                ticketToUpdate.Name = ticket.Name;
                ticketToUpdate.Description = ticketToUpdate.Description;
                ticketToUpdate.TicketTypeId = ticketToUpdate.TicketTypeId;
                ticketToUpdate.TicketStatusId = ticketToUpdate.TicketStatusId;
                ticketToUpdate.TicketPriorityId = ticketToUpdate.TicketPriorityId;

                ticket.ModifiedDate = DateTime.Now;
            }

            return ticketToUpdate;
        }
    }
}
