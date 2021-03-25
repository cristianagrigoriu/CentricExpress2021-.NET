using System;
using System.Collections.Generic;
using System.Linq;
using Flights.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data
{
    public class DatabaseContext : DbContext
    {
        private static readonly Guid Flight1Id = Guid.NewGuid();
        private static readonly Guid Flight2Id = Guid.NewGuid();

        public DatabaseContext(DbContextOptions<DatabaseContext> opts)
        : base(opts)
        {

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new List<Flight>
            {
                new Flight(
                    Flight1Id,
                    "B1",
                    new DateTime(2021, 3, 1, 8, 0, 0),
                    new DateTime(2021, 3, 1, 8, 0, 0),
                    "Iasi",
                    "Amsterdam"),
                new Flight(
                    Flight2Id,
                    "B6",
                    new DateTime(2021, 3, 1, 8, 0, 0),
                    new DateTime(2021, 3, 1, 8, 0, 0),
                    "Iasi",
                    "Londra"),
            });

            modelBuilder.Entity<Reservation>().HasData(new List<Reservation>
            {
                new Reservation(Guid.NewGuid(), "Popa Ion", Flight1Id),
                new Reservation(Guid.NewGuid(), "Rusu Lara", Flight1Id),
                new Reservation(Guid.NewGuid(), "Popescu Vasile", Flight2Id),
                new Reservation(Guid.NewGuid(), "Frunza Ioana", Flight2Id)
            });
        }
    }
}
