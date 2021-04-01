using System;
using System.Collections.Generic;
using System.Linq;
using Flights.Business;
using Flights.Business.Dto;
using Flights.WebApi.Controllers;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Flights.Data.Tests
{
    public class FlightsControllerTests
    {
        private FlightsController flightController;
        private Mock<IFlightBusiness> flightBusiness;

        private static readonly List<FlightDto> FlightsThatDifferInLength = new List<FlightDto>
        {
            new FlightDto(
                new Guid("e199e038-3433-45b0-b71e-b26ff4885ac7"), 
                "737",
                new DateTime(2021, 4, 10, 3, 0, 0),
                new DateTime(2021, 4, 10, 4, 0, 0),
                "Iasi",
                "Moscova"),
            new FlightDto(
                new Guid("0b9cc32d-3fca-4e09-8235-258767a61e2a"),
                "737",
                new DateTime(2021, 4, 10, 3, 0, 0),
                new DateTime(2021, 4, 10, 5, 0, 0),
                "Iasi",
                "Moscova")
        };

        private static readonly List<FlightDto> FlightsWithSameLength = new List<FlightDto>
        {
            new FlightDto(
                new Guid("e199e038-3433-45b0-b71e-b26ff4885ac7"),
                "737",
                new DateTime(2021, 4, 10, 3, 0, 0),
                new DateTime(2021, 4, 10, 4, 0, 0),
                "Iasi",
                "Moscova"),
            new FlightDto(
                new Guid("0b9cc32d-3fca-4e09-8235-258767a61e2a"),
                "737",
                new DateTime(2021, 4, 10, 3, 0, 0),
                new DateTime(2021, 4, 10, 4, 0, 0),
                "Iasi",
                "Moscova")
        };

        [SetUp]
        public void Setup()
        {
            this.flightBusiness = new Mock<IFlightBusiness>();
        }

        [Test]
        public void Should_ReturnOneHourFlight_When_ChoosingBetweenDifferentFlights()
        {
            //Arrange
            this.flightBusiness.Setup(x => x.GetAll()).Returns(FlightsThatDifferInLength);
            this.flightController = new FlightsController(flightBusiness.Object);

            //Act
            var shortestFlight = this.flightController
                .GetShortestFlight("Iasi", "Moscova")
                .ToList();

            //Assert
            shortestFlight.Count().Should().Be(1);
            shortestFlight.First().Id.ToString().Should().Be("0b9cc32d-3fca-4e09-8235-258767a61e2a");
        }

        [Test]
        public void Should_ReturnBothFlights_When_FlightsHaveSameLength()
        {
            //Arrange
            this.flightBusiness.Setup(x => x.GetAll()).Returns(FlightsWithSameLength);
            this.flightController = new FlightsController(flightBusiness.Object);

            //Act
            var shortestFlight = this.flightController
                .GetShortestFlight("Iasi", "Moscova")
                .ToList();

            //Assert
            shortestFlight.Count().Should().Be(2);
            shortestFlight.First().Id.ToString().Should().Be("e199e038-3433-45b0-b71e-b26ff4885ac7");
            shortestFlight.Last().Id.ToString().Should().Be("0b9cc32d-3fca-4e09-8235-258767a61e2a");
        }
    }
}
