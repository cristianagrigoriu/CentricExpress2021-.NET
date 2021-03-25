using System;
using System.Collections.Generic;
using Flights.Data.Entities;

namespace Flights.Data
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Get();
        Reservation GetById(Guid id);
        void Save();
        void Add(Reservation reservation);
        void Delete(Guid id);
        void Edit(Reservation reservation);
        bool Exists(Guid id);
    }
}
