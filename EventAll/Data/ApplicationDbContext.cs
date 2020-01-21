using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventAll.Models;

namespace EventAll.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
        public DbSet<EventStaff> EventStaffs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventVenue>()
                .HasKey(c => new { c.EventID, c.VenueID });
            modelBuilder.Entity<EventStaff>()
                .HasKey(c => new { c.EventID, c.StaffID });
        }

    }
}
