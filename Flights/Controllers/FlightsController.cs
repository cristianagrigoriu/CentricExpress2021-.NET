﻿using System;
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

        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] FlightDto flight)
        {
            this.flightBusiness.Update(id, flight);
            return Ok(flight);
        }

        [HttpDelete]

        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            this.flightBusiness.Delete(id);
            return Ok();
        }
    }
}
