using System;
using System.Collections.Generic;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<TicketType> AllTicketTypes { get; }

        IEnumerable<TicketType> AllTicketStatuses { get; }

        IEnumerable<TicketType> AllTicketPriorities { get; }

        Ticket AddTicket(Ticket ticket);

        Ticket DeleteTicket(int ticketId);

        Ticket GetTicketById(int ticketId);

        Ticket UpdateTicket(Ticket ticket);

        int Commit();
    }
}
