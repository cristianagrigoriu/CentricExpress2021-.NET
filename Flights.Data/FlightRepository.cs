using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flights.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FlightRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Flight> Get()
        {
            return _databaseContext.Set<Flight>()
                .AsNoTracking()
                .Include(flight => flight.Reservations);
        }

        public Flight GetById(Guid id)
        {
            return _databaseContext.Set<Flight>()
                .Include(fl => fl.Reservations)
                .SingleOrDefault(f => f.Id == id);
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Add(Flight flight)
        {
            _databaseContext.Set<Flight>().Add(flight);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var flight = _databaseContext.Set<Flight>().FirstOrDefault(fl => fl.Id == id);
            if (flight != null) _databaseContext.Entry((object) flight).State = EntityState.Deleted;
            _databaseContext.SaveChanges();
        }

        public void Edit(Flight flight)
        {
            _databaseContext.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _databaseContext.Set<Flight>().AsNoTracking().Any(fl => fl.Id == id);
        }
    }
}
