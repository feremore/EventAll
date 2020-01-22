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
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<EventEquipment> EventEquipments { get; set; }        
        public DbSet<EventStaff> EventStaffs { get; set; }
        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<EventStaff>()
                .HasKey(c => new { c.EventID, c.StaffID });
            modelBuilder.Entity<EventEquipment>()
                .HasKey(c => new { c.EventID, c.EquipmentID });
        }

    }
}
