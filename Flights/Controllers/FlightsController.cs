using System;
using Flights.Business;
using Flights.Business.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Flights.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        public readonly IFlightBusiness flightBusiness;

        public FlightsController(IFlightBusiness flightBusiness)
        {
            this.flightBusiness = flightBusiness;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var flights = this.flightBusiness.GetAll();
            return Ok(flights);
        }

        [HttpPost]
        public IActionResult Add([FromBody] FlightDto flight)
        {
            this.flightBusiness.Add(flight);
            return Ok(flight);
        }


        [HttpPut]
        public IActionResult Put([FromBody] FlightDto flight)
        {
            this.flightBusiness.Update(flight);
            return Ok(flight);
        }

        [HttpDelete]
        public IActionResult Delete(Guid flightId)
        {
            this.flightBusiness.Delete(flightId);
            return Ok();
        }
    }
}
