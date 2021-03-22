using System;

namespace Flights.Business.Dto
{
    public class ReservationDto
    {
        public ReservationDto()
        {
        }

        public ReservationDto(Guid id, string user, Guid flightId)
        {
            User = user;
            FlightId = flightId;
            Id = id;
        }

        public Guid Id { get; set; }

        public string User { get; set; }

        public Guid FlightId { get; set; }
    }
}
