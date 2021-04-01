using System;
using System.IO;
using Flights.Business.Dto;
using Flights.Data.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Flights.Data.Tests
{
    public class FlightTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Should_ReturnOneHour_When_FlightLastsOneHour()
        {
            //Arrange
            var flight = new FlightDto(
                Guid.NewGuid(),
                "737",
                new DateTime(2021, 4, 10, 3, 0, 0),
                new DateTime(2021, 4, 10, 4, 0, 0),
                "Iasi",
                "Moscova");

            //Act && Assert
            flight.GetFlightDuration().Should().Be(new TimeSpan(1, 0, 0));
        }

        [Test]
        public void Should_ReturnError_When_FlightArrivalTimeIsBeforeDepartureTime()
        {
            //Arrange
            var flight = new FlightDto(
                Guid.NewGuid(),
                "737",
                new DateTime(2021, 4, 10, 4, 0, 0),
                new DateTime(2021, 4, 10, 3, 0, 0),
                "Iasi",
                "Moscova");

            //Act
            Action action = () => flight.GetFlightDuration();

            //Assert
            action.Should().Throw<InvalidDataException>()
                .WithMessage("Arrival time cannot be before Departure time!");
        }

        [Test]
        public void Should_ReturnError_When_FlightHasZeroHours()
        {
            //Arrange
            var flight = new FlightDto(
                Guid.NewGuid(),
                "737",
                new DateTime(2021, 4, 10, 4, 0, 0),
                new DateTime(2021, 4, 10, 4, 0, 0),
                "Iasi",
                "Moscova");

            //Act
            Action action = () => flight.GetFlightDuration();

            //Assert
            action.Should().Throw<InvalidDataException>()
                .WithMessage("Departure time cannot be equal to Arrival time!");
        }
    }
}