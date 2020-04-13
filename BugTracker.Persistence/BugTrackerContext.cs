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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Seed TicketType
        //    foreach(var type in Enum.GetNames(typeof(Enums.TicketType)))
        //    {
        //        modelBuilder.Entity<TicketType>().HasData(new TicketType
        //        {
        //            Id = (int)Enum.Parse(typeof(Enums.TicketType), type),
        //            Name = type
        //        });
        //    }

        //    // Seed TicketStatus
        //    foreach (var status in Enum.GetNames(typeof(Enums.TicketStatus)))
        //    {
        //        modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus
        //        {
        //            Id = (int)Enum.Parse(typeof(Enums.TicketStatus), status),
        //            Name = status
        //        });
        //    }

        //    // Seed TicketPriority
        //    foreach (var priority in Enum.GetNames(typeof(Enums.TicketPriority)))
        //    {
        //        modelBuilder.Entity<TicketPriority>().HasData(new TicketPriority
        //        {
        //            Id = (int)Enum.Parse(typeof(Enums.TicketPriority), priority),
        //            Name = priority
        //        });
        //    }

        //    // Seed projects
        //    modelBuilder.Entity<Project>().HasData(new Project
        //    {
        //        Id = 1,
        //        Name = "Test Project 1",
        //        Description = "Dummy project for testing",
        //    });

        //    modelBuilder.Entity<Project>().HasData(new Project
        //    {
        //        Id = 2,
        //        Name = "Test Project 2",
        //        Description = "Dummy project for testing",
        //    });

        //    // Seed Tickets
        //    modelBuilder.Entity<Ticket>().HasData(new Ticket
        //    {
        //        Id = 1,
        //        Name = "Missing user nav menu",
        //        Description = "Link to dashboard page missing in nav",
        //        CreatedDate = DateTime.Now,
        //        ProjectId = 1,
        //        TicketTypeId = (int)Enums.TicketType.Bug,
        //        TicketStatusId = (int)Enums.TicketStatus.ToDo,
        //        TicketPriorityId = (int)Enums.TicketPriority.Medium,
        //    });

        //    modelBuilder.Entity<Ticket>().HasData(new Ticket
        //    {
        //        Id = 1,
        //        Name = "Missing dashboard nav menu",
        //        Description = "Link to dashboard page missing in nav",
        //        CreatedDate = DateTime.Now,
        //        ProjectId = 1,
        //        TicketTypeId = (int)Enums.TicketType.Bug,
        //        TicketStatusId = (int)Enums.TicketStatus.InProgress,
        //        TicketPriorityId = (int)Enums.TicketPriority.Medium,
        //    });
        //}
    }
}
