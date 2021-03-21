using System;

namespace Flights.Models
{
    public class Flight
    {
        public Guid Id { get; set; }

        public string PlaneModel { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string DepartureCity { get; set; }

        public string DestinationCity { get; set; }
    }
}
