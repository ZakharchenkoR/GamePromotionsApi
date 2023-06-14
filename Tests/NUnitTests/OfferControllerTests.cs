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
    internal class OfferControllerTests
    {
        private Mock<IOfferService> _mockOfferService;
        private Mock<IBroadcaster> _mockBroadcaster;
        private OfferController _offerController;

        [SetUp]
        public void Setup()
        {
            _mockOfferService = new Mock<IOfferService>();
            _mockBroadcaster = new Mock<IBroadcaster>();

            _offerController = new OfferController(_mockOfferService.Object, _mockBroadcaster.Object);
        }

        [Test]
        public async Task Get_ReturnsOkWithOffers()
        {
            // Arrange
            var offers = GetOffersModels();
            _mockOfferService.Setup(service => service.GetOffers()).ReturnsAsync(offers);

            // Act
            var result = await _offerController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(offers, okResult.Value);
        }

        [Test]
        public async Task Post_ReturnsOkWithAddedOffers()
        {
            // Arrange
            var offerModel = new AddOfferModel()
            {
                Name = "Test",
                StartsAt = DateTime.Now,
                ExpiresAt = DateTime.Now,
                OfferType = OfferTypes.GameCurrencyPack
            };

            var returnedOffer = new OfferModel()
            {
                Id = 1,
                Name = "Test",
                StartsAt = DateTime.Now,
                ExpiresAt = DateTime.Now,
                OfferType = OfferTypes.GameCurrencyPack
            };

            _mockOfferService.Setup(service => service.AddOffer(It.IsAny<AddOfferModel>())).ReturnsAsync(returnedOffer);

            // Act
            var result = await _offerController.Post(offerModel);

            // Assert
            _mockOfferService.Verify(service => service.AddOffer(It.Is<AddOfferModel>(e => e == offerModel)), Times.Once());
            _mockBroadcaster.Verify(service => service.BroadcastPromotion(It.IsAny<IPromotion>()), Times.Once());
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(returnedOffer, okResult.Value);
        }

        private List<OfferModel> GetOffersModels()
        {
            return new List<OfferModel> {
                new OfferModel
                {
                    Id = 1,
                    Name = "Test",
                    StartsAt = DateTime.Now,
                    ExpiresAt = DateTime.Now,
                    OfferType = OfferTypes.GameCurrencyPack
                },
                new OfferModel
                {
                    Id = 1,
                    Name = "Test",
                    StartsAt = DateTime.Now,
                    ExpiresAt = DateTime.Now,
                    OfferType = OfferTypes.DiscountedItemPurchase
                }
            };
        }
    }
}
