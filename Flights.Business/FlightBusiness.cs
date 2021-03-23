using System;
using System.Collections.Generic;
using System.Linq;
using Flights.Business.Dto;
using Flights.Data;
using Flights.Data.Entities;

namespace Flights.Business
{
    public class FlightBusiness: IFlightBusiness
    {
        public List<FlightDto> GetAll()
        {
            return Database.Flights.Select(f => new FlightDto(
                f.Id,
                f.PlaneModel,
                f.DepartureTime,
                f.ArrivalTime,
                f.DepartureCity,
                f.DestinationCity)).ToList();
        }

        public void Add(FlightDto flight)
        {
            var newFlight = new Flight(
                flight.Id,
                flight.PlaneModel,
                flight.DepartureTime,
                flight.ArrivalTime,
                flight.DepartureCity,
                flight.DestinationCity);

            Database.Flights.Add(newFlight);
        }

        public void Update(Guid flightId, FlightDto flightDto)
        {
            var flight = Database.Flights.Find(fl => fl.Id == flightId);
            flight.Update(flightDto.PlaneModel,
                flightDto.DepartureTime,
                flightDto.ArrivalTime,
                flightDto.DepartureCity,
                flightDto.DestinationCity);
        }

        public void Delete(Guid flightId)
        {
            Database.Flights = Database.Flights.Where(r => r.Id != flightId).ToList();
        }
    }
}
