using System;
using System.Collections.Generic;
using Flights.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private static List<Reservation> reservations = new List<Reservation>
        {
            new Reservation
            {
                UserName = "Amir",
                FlightId = Guid.NewGuid()
            },
            new Reservation
            {
                UserName = "Betty",
                FlightId = Guid.NewGuid()
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reservations);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Reservation reservation)
        {
            reservations.Add(reservation);
            return Ok(reservation);
        }
    }
}
