using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> AllTickets { get; }

        IEnumerable<TicketType> AllTicketTypes { get; }

        IEnumerable<TicketStatus> AllTicketStatuses { get; }

        IEnumerable<TicketPriority> AllTicketPriorities { get; }

        Task<Ticket> AddTicketAsync(Ticket ticket);

        Task<Ticket> DeleteTicketAsync(int ticketId);

        Task<Ticket> GetTicketByIdAsync(int ticketId);

        Ticket UpdateTicket(Ticket ticket);

        Task<int> CommitAsync();
    }
}
