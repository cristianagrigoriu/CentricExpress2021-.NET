using System;

namespace Flights.Data.Entities
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(Guid id, string user, Guid flightId)
        {
            User = user;
            FlightId = flightId;
            Id = id;
        }

        public Guid Id { get; private set; }

        public string User { get; private set; }

        public Guid FlightId { get; private set; }
    }
}
