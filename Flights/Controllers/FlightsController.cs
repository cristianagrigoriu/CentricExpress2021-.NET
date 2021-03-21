using System;
using System.Collections.Generic;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private static List<Flight> flights = new List<Flight>
        {
            new Flight
            {
                Id = Guid.NewGuid(),
                PlaneModel = "Boeing 707",
                DepartureCity = "Iasi",
                DestinationCity = "Bucharest",
                DepartureTime = new DateTime(2021, 3, 1, 8, 0, 0),
                ArrivalTime = new DateTime(2021, 3, 1, 9, 0, 0)
            },
            new Flight
            {
                Id = Guid.NewGuid(),
                PlaneModel = "Airbus A340",
                DepartureCity = "Bucharest",
                DestinationCity = "Vienna",
                DepartureTime = new DateTime(2021, 3, 1, 10, 0, 0),
                ArrivalTime = new DateTime(2021, 3, 1, 12, 0, 0)
            },
            new Flight
            {
                Id = Guid.NewGuid(),
                PlaneModel = "Airbus A340",
                DepartureCity = "Vienna",
                DestinationCity = "Casablanca",
                DepartureTime = new DateTime(2021, 3, 1, 13, 0, 0),
                ArrivalTime = new DateTime(2021, 3, 1, 18, 0, 0)
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(flights);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Flight flight)
        {
            flights.Add(flight);
            return Ok(flight);
        }
    }
}
