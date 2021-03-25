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
        private readonly IFlightRepository _flightRepository;

        public FlightBusiness(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public List<FlightDto> GetAll()
        {
            return _flightRepository.Get()
                .Select(MapToFlightModel)
                .ToList();
        }

        public void Add(FlightDto flightDto)
        {
            var flight = new Flight(flightDto.Id, flightDto.PlaneModel, flightDto.DepartureTime, flightDto.ArrivalTime,
                flightDto.DepartureCity, flightDto.DestinationCity);
            _flightRepository.Add(flight);
        }

        public void Update(Guid flightId, FlightDto flightDto)
        {
            var flight = _flightRepository.GetById(flightId);
            flight.Update(flightDto.PlaneModel, flightDto.DepartureTime, flightDto.ArrivalTime,
                flightDto.DepartureCity, flightDto.DestinationCity);
            _flightRepository.Edit(flight);
        }

        public void Delete(Guid flightId)
        {
            _flightRepository.Delete(flightId);
        }

        public bool Exists(Guid id)
        {
            return _flightRepository.Exists(id);
        }

        private FlightDto MapToFlightModel(Flight flight)
        {
            return new FlightDto
            {
                Id = flight.Id,
                ArrivalTime = flight.ArrivalTime,
                DepartureCity = flight.DepartureCity,
                DepartureTime = flight.DepartureTime,
                DestinationCity = flight.DestinationCity,
                PlaneModel = flight.PlaneModel,
                Reservations = MapReservations(flight),
            };
        }

        private List<ReservationDto> MapReservations(Flight flight)
        {
            if (flight.Reservations != null && flight.Reservations.Any())
            {
                return flight.Reservations.Select(res =>
                    new ReservationDto()
                    {
                        Id = res.Id,
                        FlightId = res.FlightId,
                        User = res.User
                    }).ToList();
            }

            return new List<ReservationDto>();
        }
    }
}
