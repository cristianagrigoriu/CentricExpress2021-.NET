using System;
using System.Collections.Generic;
using Flights.Business.Dto;

namespace Flights.Business
{
    public interface IReservationBusiness
    {
        List<ReservationDto> GetAll();

        void Add(ReservationDto reservation);

        void Update(Guid reservationId, ReservationDto reservation);

        void Delete(Guid reservationId);

        ReservationDto GetById(Guid id);
    }
}
