using System;
using System.Collections.Generic;
using System.Linq;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using Enums = BugTracker.Domain.Enums;

namespace BugTracker.Persistence
{
    public class InMemoryTicketRepository : ITicketRepository
    {
        List<Ticket> tickets;
        List<TicketType> ticketTypes;
        List<TicketStatus> ticketStatuses;
        List<TicketPriority> ticketPriorities;

        public InMemoryTicketRepository()
        {
            ticketTypes = Enum.GetNames(typeof(TicketType))
                .Select(x => new TicketType
                {
                    Id = (int)Enum.Parse(typeof(TicketType), x),
                    Name = x
                })
                .ToList();
            ticketStatuses = Enum.GetNames(typeof(TicketStatus))
                .Select(x => new TicketStatus
                {
                    Id = (int)Enum.Parse(typeof(TicketStatus), x),
                    Name = x
                })
                .ToList();
            ticketPriorities = Enum.GetNames(typeof(TicketPriority))
                .Select(x => new TicketPriority
                {
                    Id = (int)Enum.Parse(typeof(TicketPriority), x),
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
                    TicketStatusId = (int)Enums.TicketStatus.ToDo,
                    TicketPriorityId = (int)Enums.TicketPriority.Medium
                },
                new Ticket
                {
                    Id = 2,
                    Name = "Add blog page",
                    Description = "Create new page for blog posts",
                    CreatedDate = DateTime.Now,
                    TicketTypeId = (int)Enums.TicketType.Bug,
                    TicketStatusId = (int)Enums.TicketStatus.ToDo,
                    TicketPriorityId = (int)Enums.TicketPriority.Medium
                }
            };

        }

        public IEnumerable<TicketType> AllTicketTypes => throw new NotImplementedException();

        public IEnumerable<TicketType> AllTicketStatuses => throw new NotImplementedException();

        public IEnumerable<TicketType> AllTicketPriorities => throw new NotImplementedException();

        public Ticket AddTicket(Ticket ticket)
        {
            ticket.Id = tickets.Max(t => t.Id) + 1;
            ticket.CreatedDate = DateTime.Now; // TODO: Move to machine time service
            ticket.ModifiedDate = DateTime.Now;
            tickets.Add(ticket);
            return ticket;
        }

        public int Commit()
        {
            return 0;
        }

        public Ticket DeleteTicket(int ticketId)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == ticketId);
            return ticket;
        }

        public Ticket GetTicketById(int ticketId)
        {
            return tickets.SingleOrDefault(t => t.Id == ticketId);
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
