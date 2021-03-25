using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.Data.Entities
{
    public class Flight
    {
        public Flight()
        {
        }

        public Flight(Guid id, string planeModel, DateTime departureTime, DateTime arrivalTime, string departureCity, string destinationCity)
        {
            Id = id;
            PlaneModel = planeModel;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string PlaneModel { get; private set; }

        public DateTime DepartureTime { get; private set; }

        public DateTime ArrivalTime { get; private set; }

        public string DepartureCity { get; private set; }

        public string DestinationCity { get; private set; }

        public List<Reservation> Reservations { get; private set; }

        public void Update(string planeModel, DateTime departureTime, DateTime arrivalTime, string departureCity,
            string destinationCity)
        {
            PlaneModel = planeModel;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
        }
    }
}
