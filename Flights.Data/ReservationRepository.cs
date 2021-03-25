using System;
using System.Collections.Generic;
using System.Linq;
using Flights.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReservationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Reservation> Get()
        {
            return this._databaseContext.Set<Reservation>()
                .AsNoTracking();
        }

        public Reservation GetById(Guid id)
        {
            return _databaseContext.Set<Reservation>()
                .SingleOrDefault(res => res.Id == id);
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Add(Reservation reservation)
        {
            _databaseContext.Set<Reservation>().Add(reservation);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var reservation = _databaseContext.Set<Reservation>().FirstOrDefault(res => res.Id == id);
            if (reservation != null) _databaseContext.Entry((object) reservation).State = EntityState.Deleted;
            _databaseContext.SaveChanges();
        }

        public void Edit(Reservation reservation)
        {
            _databaseContext.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _databaseContext.Set<Reservation>().Any(res => res.Id == id);
        }
    }
}
