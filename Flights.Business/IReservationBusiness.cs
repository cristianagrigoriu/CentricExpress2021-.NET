using System;
using System.Collections.Generic;
using Flights.Business.Dto;

namespace Flights.Business
{
    public interface IReservationBusiness
    {
        List<ReservationDto> GetAll();

        void Add(ReservationDto reservation);

        void Update(ReservationDto reservation);

        void Delete(Guid reservationId);
    }
}
