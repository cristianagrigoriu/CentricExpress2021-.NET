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
        private readonly IReservationRepository _reservationRepository;

        public ReservationBusiness(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationDto> GetAll()
        {
            return _reservationRepository.Get()
                .Select(MapToReservationModel)
                .ToList();
        }

        public void Add(ReservationDto reservation)
        {
            var newReservation = new Reservation(reservation.Id, reservation.User, reservation.FlightId);
            _reservationRepository.Add(newReservation);
        }

        public void Update(Guid reservationId, ReservationDto reservationDto)
        {
            var reservation = _reservationRepository.GetById(reservationId);
            reservation.Update(reservationDto.User, reservationDto.FlightId);
            _reservationRepository.Edit(reservation);
        }

        public void Delete(Guid reservationId)
        {
            _reservationRepository.Delete(reservationId);
        }

        public ReservationDto GetById(Guid id)
        {
            var reservation = _reservationRepository.GetById(id);
            return MapToReservationModel(reservation);
        }

        private ReservationDto MapToReservationModel(Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                User = reservation.User,
                FlightId = reservation.FlightId
            };
        }
    }
}
