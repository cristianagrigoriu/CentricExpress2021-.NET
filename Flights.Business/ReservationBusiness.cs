using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Flights.Business.Dto;
using Flights.Data;
using Flights.Data.Entities;

namespace Flights.Business
{
    public class ReservationBusiness: IReservationBusiness
    {
        public List<ReservationDto> GetAll()
        {
            return Database.Reservations.Select(r=> new ReservationDto(r.Id, r.User, r.FlightId)).ToList();
        }

        public void Add(ReservationDto reservation)
        {
            var newReservation = new Reservation(reservation.Id, reservation.User, reservation.FlightId);

            Database.Reservations.Add(newReservation);
        }

        public void Update(ReservationDto reservation)
        {
            Delete(reservation.Id);
            Add(reservation);
        }

        public void Delete(Guid reservationId)
        {
            Database.Reservations = Database.Reservations.Where(r => r.Id != reservationId).ToList();
        }
    }
}
