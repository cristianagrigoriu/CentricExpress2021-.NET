using System;
using System.Collections.Generic;
using System.IO;

namespace Flights.Business.Dto
{
    public class FlightDto
    {
        public FlightDto()
        {
        }

        public FlightDto(Guid id, string planeModel, DateTime departureTime, DateTime arrivalTime, string departureCity, string destinationCity)
        {
            Id = id;
            PlaneModel = planeModel;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
        }

        public Guid Id { get; set; }

        public string PlaneModel { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string DepartureCity { get; set; }

        public string DestinationCity { get; set; }

        public List<ReservationDto> Reservations { get; set; }

        public TimeSpan GetFlightDuration()
        {
            var flightDuration = this.ArrivalTime - this.DepartureTime;

            if (flightDuration.TotalHours < 0)
            {
                throw new InvalidDataException("Arrival time cannot be before Departure time!");
            }

            if (flightDuration.TotalHours == 0)
            {
                throw new InvalidDataException("Departure time cannot be equal to Arrival time!");
            }

            return flightDuration;
        }
    }
}
