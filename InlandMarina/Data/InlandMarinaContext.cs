using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InlandMarina.Models;

namespace InlandMarina.Data
{
    public class InlandMarinaContext : DbContext
    {
        public InlandMarinaContext(DbContextOptions<InlandMarinaContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dock> Docks { get; set; }
        public DbSet<Slip> Slips { get; set; }
        public DbSet<Lease> Leases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=InlandMarina;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<Customer>().HasData(
                new Customer { ID = 1, FirstName = "John", LastName = "Doe", Phone = "265-555-1212", City = "Phoenix" },
                new Customer { ID = 2, FirstName = "Sara", LastName = "Williams", Phone = "403-555-9585", City = "Calgary" },
                new Customer { ID = 3, FirstName = "Ken", LastName = "Wong", Phone = "802-555-3214", City = "Kansas City" }
            );

            modelBuilder.Entity<Dock>().HasData(
                new Dock { ID = 1, Name = "Dock A", WaterService = true, ElectricalService = true },
                new Dock { ID = 2, Name = "Dock B", WaterService = true, ElectricalService = false },
                new Dock { ID = 3, Name = "Dock C", WaterService = false, ElectricalService = true }
            );

            modelBuilder.Entity<Slip>().HasData(
                new Slip { ID = 1, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 2, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 3, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 4, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 5, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 6, Width = 8, Length = 16, DockID = 1 },
                new Slip { ID = 7, Width = 8, Length = 20, DockID = 1 },
                new Slip { ID = 8, Width = 8, Length = 20, DockID = 1 },
                new Slip { ID = 9, Width = 8, Length = 20, DockID = 1 },
                new Slip { ID = 10, Width = 8, Length = 20, DockID = 1 },
                new Slip { ID = 11, Width = 8, Length = 20, DockID = 1 },
                new Slip { ID = 12, Width = 8, Length = 22, DockID = 1 },
                new Slip { ID = 13, Width = 8, Length = 22, DockID = 1 },
                new Slip { ID = 14, Width = 8, Length = 22, DockID = 1 },
                new Slip { ID = 15, Width = 8, Length = 22, DockID = 1 },
                new Slip { ID = 16, Width = 8, Length = 24, DockID = 1 },
                new Slip { ID = 17, Width = 8, Length = 24, DockID = 1 },
                new Slip { ID = 18, Width = 8, Length = 24, DockID = 1 },
                new Slip { ID = 19, Width = 8, Length = 24, DockID = 1 },
                new Slip { ID = 20, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 21, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 22, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 23, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 24, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 25, Width = 8, Length = 26, DockID = 1 },
                new Slip { ID = 26, Width = 8, Length = 28, DockID = 1 },
                new Slip { ID = 27, Width = 8, Length = 28, DockID = 1 },
                new Slip { ID = 28, Width = 8, Length = 28, DockID = 1 },
                new Slip { ID = 29, Width = 8, Length = 28, DockID = 1 },
                new Slip { ID = 30, Width = 8, Length = 28, DockID = 1 },
                 new Slip { ID = 31, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 32, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 33, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 34, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 35, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 36, Width = 8, Length = 18, DockID = 2 },
                new Slip { ID = 37, Width = 8, Length = 20, DockID = 2 },
                new Slip { ID = 38, Width = 8, Length = 20, DockID = 2 },
                new Slip { ID = 39, Width = 8, Length = 20, DockID = 2 },
                new Slip { ID = 40, Width = 8, Length = 22, DockID = 2 },
                new Slip { ID = 41, Width = 8, Length = 22, DockID = 2 },
                new Slip { ID = 42, Width = 8, Length = 22, DockID = 2 },
                new Slip { ID = 43, Width = 8, Length = 24, DockID = 2 },
                new Slip { ID = 44, Width = 8, Length = 24, DockID = 2 },
                new Slip { ID = 45, Width = 8, Length = 24, DockID = 2 },
                new Slip { ID = 46, Width = 8, Length = 24, DockID = 2 },
                new Slip { ID = 47, Width = 8, Length = 28, DockID = 2 },
                new Slip { ID = 48, Width = 8, Length = 28, DockID = 2 },
                new Slip { ID = 49, Width = 8, Length = 28, DockID = 2 },
                new Slip { ID = 50, Width = 8, Length = 30, DockID = 2 },
                new Slip { ID = 51, Width = 8, Length = 30, DockID = 2 },
                new Slip { ID = 52, Width = 8, Length = 30, DockID = 2 },
                new Slip { ID = 53, Width = 8, Length = 30, DockID = 2 },
                new Slip { ID = 54, Width = 8, Length = 30, DockID = 2 },
                new Slip { ID = 55, Width = 8, Length = 32, DockID = 2 },
                new Slip { ID = 56, Width = 8, Length = 32, DockID = 2 },
                new Slip { ID = 57, Width = 8, Length = 32, DockID = 2 },
                new Slip { ID = 58, Width = 8, Length = 32, DockID = 2 },
                new Slip { ID = 59, Width = 8, Length = 32, DockID = 2 },
                new Slip { ID = 60, Width = 8, Length = 32, DockID = 2 },
                 new Slip { ID = 61, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 62, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 63, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 64, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 65, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 66, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 67, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 68, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 69, Width = 10, Length = 22, DockID = 3 },
                new Slip { ID = 70, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 71, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 72, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 73, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 74, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 75, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 76, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 77, Width = 10, Length = 24, DockID = 3 },
                new Slip { ID = 78, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 79, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 80, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 81, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 82, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 83, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 84, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 85, Width = 12, Length = 28, DockID = 3 },
                new Slip { ID = 86, Width = 12, Length = 32, DockID = 3 },
                new Slip { ID = 87, Width = 12, Length = 32, DockID = 3 },
                new Slip { ID = 88, Width = 12, Length = 32, DockID = 3 },
                new Slip { ID = 89, Width = 12, Length = 32, DockID = 3 },
                new Slip { ID = 90, Width = 12, Length = 32, DockID = 3 }
            );

            modelBuilder.Entity<Lease>().HasData(
                new Lease { ID = 1, SlipID = 20, CustomerID = 1 },
                new Lease { ID = 2, SlipID = 42, CustomerID = 2 },
                new Lease { ID = 3, SlipID = 88, CustomerID = 3 }
            );
        }
    }
}
