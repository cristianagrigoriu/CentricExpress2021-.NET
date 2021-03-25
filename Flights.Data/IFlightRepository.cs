using System;
using System.Collections.Generic;
using System.Text;
using Flights.Data.Entities;

namespace Flights.Data
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> Get();
        Flight GetById(Guid id);
        void Save();
        void Add(Flight flight);
        void Delete(Guid id);
        void Edit(Flight flight);
        bool Exists(Guid id);
    }
}
