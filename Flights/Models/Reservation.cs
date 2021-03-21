using System;

namespace Flights.WebApi.Models
{
    public class Reservation
    {
        public string UserName { get; set; }

        public Guid FlightId { get; set; }
    }
}
