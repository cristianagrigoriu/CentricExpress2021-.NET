using System;
using Flights.Business;
using Flights.Business.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Flights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public readonly IReservationBusiness reservationBusiness;

        public ReservationController(IReservationBusiness reservationBusiness)
        {
            this.reservationBusiness = reservationBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reservations = this.reservationBusiness.GetAll();
            return Ok(reservations);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReservationDto reservation)
        {
            this.reservationBusiness.Add(reservation);
            return Ok(reservation);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReservationDto reservation)
        {
            this.reservationBusiness.Update(reservation);
            return Ok(reservation);
        }

        [HttpDelete]
        public IActionResult Delete(Guid reservationId)
        {
            this.reservationBusiness.Delete(reservationId);
            return Ok();
        }
    }
}
