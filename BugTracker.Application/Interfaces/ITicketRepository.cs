using System;
using System.Collections.Generic;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> AllTickets { get; }

        IEnumerable<TicketType> AllTicketTypes { get; }

        IEnumerable<TicketStatus> AllTicketStatuses { get; }

        IEnumerable<TicketPriority> AllTicketPriorities { get; }

        Ticket AddTicket(Ticket ticket);

        Ticket DeleteTicket(int ticketId);

        Ticket GetTicketById(int ticketId);

        Ticket UpdateTicket(Ticket ticket);

        int Commit();
    }
}
