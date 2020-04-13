using System;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = BugTracker.Domain.Enums;

namespace BugTracker.Persistence
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedTicketTypes(modelBuilder);
            SeedTicketStatuses(modelBuilder);
            SeedTicketPriorities(modelBuilder);
            SeedProjects(modelBuilder);
            SeedTickets(modelBuilder);
            
        }

        private void SeedTicketTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketType>().HasData(new TicketType
            {
                Id = 1,
                Name = "Bug",
                Description = "There is a defect in the application code or logic",
            });

            modelBuilder.Entity<TicketType>().HasData(new TicketType
            {
                Id = 2,
                Name = "Enhancement",
                Description = "There is a request for new functionality for the application",
            });
        }

        private void SeedTicketStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 1,
                Name = "To Do",
                Description = "The issue has been reported and is waiting for the team to action it.",
            });

            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 2,
                Name = "Open",
                Description = "The issue is open and ready for the assignee to start work on it.",
            });

            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 3,
                Name = "In Progress",
                Description = "This issue is being actively worked on at the moment by the assignee.",
            });

            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 4,
                Name = "Resolved",
                Description = "A resolution has been taken, and it is awaiting verification by reporter. From here, issues are either reopened, or are closed.",
            });

            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 5,
                Name = "Reopened",
                Description = "This issue was once resolved, but the resolution was deemed incorrect. From here, issues are either marked assigned or resolved.",
            });

            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
            {
                Id = 6,
                Name = "Closed",
                Description = "The issue is considered finished. The resolution is correct. Issues which are closed can be reopened.",
            });
        }

        private void SeedTicketPriorities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
            {
                Id = 1,
                Name = "Trivial",
                Description = "Trivial problem with little or no impact on progress.",
            });

            modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
            {
                Id = 2,
                Name = "Low",
                Description = "Minor problem or easily worked around.",
            });

            modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
            {
                Id = 3,
                Name = "Medium",
                Description = "Has the potential to affect progress.",
            });

            modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
            {
                Id = 4,
                Name = "High",
                Description = "Serious problem that could block progress.",
            });

            modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
            {
                Id = 5,
                Name = "Critical",
                Description = "Problem blocks progress.",
            });
        }

        private void SeedProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 1,
                Name = "Test Project 1",
                Description = "Dummy project for testing",
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 2,
                Name = "Test Project 2",
                Description = "Dummy project for testing",
            });
        }

        private void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 1,
                Name = "Missing user nav menu",
                Description = "User menu item is missing in the nav bar",
                CreatedDate = DateTime.Now.AddDays(-7),
                ProjectId = 1,
                TicketTypeId = (int)Enums.TicketType.Bug,
                TicketStatusId = (int)Enums.TicketStatus.ToDo,
                TicketPriorityId = (int)Enums.TicketPriority.High
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 2,
                Name = "Missing dashboard nav menu",
                Description = "Link to dashboard page missing in nav",
                CreatedDate = DateTime.Now.AddDays(-1),
                ProjectId = 1,
                TicketTypeId = (int)Enums.TicketType.Bug,
                TicketStatusId = (int)Enums.TicketStatus.InProgress,
                TicketPriorityId = (int)Enums.TicketPriority.High
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 3,
                Name = "Details page",
                Description = "Create new page where the user can edit the ticket details",
                CreatedDate = DateTime.Now.AddDays(-7),
                ProjectId = 2,
                TicketTypeId = (int)Enums.TicketType.Enhancement,
                TicketStatusId = (int)Enums.TicketStatus.ToDo,
                TicketPriorityId = (int)Enums.TicketPriority.Medium
            });
        }
    }
}
