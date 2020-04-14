using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> AllTickets { get; }

        IQueryable<TicketType> AllTicketTypes { get; }

        IQueryable<TicketStatus> AllTicketStatuses { get; }

        IQueryable<TicketPriority> AllTicketPriorities { get; }

        Task<Ticket> AddTicketAsync(Ticket ticket);

        Task<Ticket> DeleteTicketAsync(int ticketId);

        Task<Ticket> GetTicketByIdAsync(int ticketId);

        Ticket UpdateTicket(Ticket ticket);

        Task<int> CommitAsync();
    }
}
