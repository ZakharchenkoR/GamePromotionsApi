using GamePromotion.API.Common;
using GamePromotion.API.Controllers;
using GamePromotion.BAL.Enums;
using GamePromotion.BAL.Models;
using GamePromotion.BAL.Models.Abstractions;
using GamePromotion.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTests
{
    public class EventControllerTests
    {
        private Mock<IEventService> _mockEventService;
        private Mock<IBroadcaster> _mockBroadcaster;
        private EventController _eventController;

        [SetUp]
        public void Setup()
        {
            _mockEventService = new Mock<IEventService>();
            _mockBroadcaster = new Mock<IBroadcaster>();

            _eventController = new EventController(_mockEventService.Object, _mockBroadcaster.Object);
        }

        [Test]
        public async Task Get_ReturnsOkWithEvents()
        {
            // Arrange
            var events = GetEventModels();
            _mockEventService.Setup(service => service.GetEvents()).ReturnsAsync(events);

            // Act
            var result = await _eventController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(events, okResult.Value);
        }

        [Test]
        public async Task Post_ReturnsOkWithAddedEvent()
        {
            // Arrange
            var eventModel = new AddEventModel() 
            { 
                Name = "Test",
                StartsAt = DateTime.Now,
                ExpiresAt = DateTime.Now,
                EventType = EventTypes.Tournament
            };

            var returnedEvent = new EventModel() 
            {
                Id = 1,
                Name = "Test",
                StartsAt =  DateTime.Now,
                ExpiresAt= DateTime.Now,
                EventType = EventTypes.Tournament
            };

            _mockEventService.Setup(service => service.AddEvent(It.IsAny<AddEventModel>())).ReturnsAsync(returnedEvent);

            // Act
            var result = await _eventController.Post(eventModel);

            // Assert
            _mockEventService.Verify(service => service.AddEvent(It.Is<AddEventModel>(e => e == eventModel)), Times.Once());
            _mockBroadcaster.Verify(service => service.BroadcastPromotion(It.IsAny<IPromotion>()), Times.Once());
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(returnedEvent, okResult.Value);
        }

        private List<EventModel> GetEventModels()
        {
            return new List<EventModel> {
                new EventModel
                {
                    Id = 1,
                    Name = "Test",
                    StartsAt = DateTime.Now,
                    ExpiresAt = DateTime.Now,
                    EventType = EventTypes.Tournament
                },
                new EventModel
                {
                    Id = 1,
                    Name = "Test",
                    StartsAt = DateTime.Now,
                    ExpiresAt = DateTime.Now,
                    EventType = EventTypes.Competition
                }
            };
        }
    }
}
