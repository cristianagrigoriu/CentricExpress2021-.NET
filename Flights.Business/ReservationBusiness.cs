using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Update(Guid reservationId, ReservationDto reservationDto)
        {
            var reservation = Database.Reservations.Find(res => res.Id == reservationId);
            reservation.Update(reservationDto.User, reservationDto.FlightId);
        }

        public void Delete(Guid reservationId)
        {
            Database.Reservations = Database.Reservations.Where(r => r.Id != reservationId).ToList();
        }

        public ReservationDto GetById(Guid id)
        {
            return Database.Reservations.Where(x => x.Id == id)
                .Select(r => new ReservationDto(r.Id, r.User, r.FlightId)).SingleOrDefault();
        }
    }
}
