using System;
using System.Collections.Generic;
using Flights.Business.Dto;

namespace Flights.Business
{
    public interface IFlightBusiness
    {
        List<FlightDto> GetAll();

        void Add(FlightDto flight);

        void Update(FlightDto flight);

        void Delete(Guid flightId);
    }
}
