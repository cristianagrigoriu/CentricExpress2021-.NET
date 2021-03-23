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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var reservation = this.reservationBusiness.GetById(id);
            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReservationDto reservation)
        {
            this.reservationBusiness.Add(reservation);
            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] ReservationDto reservation)
        {
            this.reservationBusiness.Update(id, reservation);
            return Ok(reservation);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            this.reservationBusiness.Delete(id);
            return Ok();
        }
    }
}
