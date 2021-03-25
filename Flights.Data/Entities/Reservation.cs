using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string User { get; private set; }

        public Guid FlightId { get; private set; }

        public void Update(string user, Guid flightId)
        {
            User = user;
            FlightId = flightId;
        }
    }
}
