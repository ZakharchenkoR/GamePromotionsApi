using GamePromotion.API.Hubs;
using GamePromotion.BAL.Models;
using GamePromotion.BAL.Models.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamePromotion.API.Common
{
    public class PromotionBroadcaster : IPromotionVisitor
    {
        private readonly IHubContext<GameHub> _gameHubContext;

        public PromotionBroadcaster(IHubContext<GameHub> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task Visit(OfferModel offerModel)
        {
            await _gameHubContext.Clients.All.SendAsync("ReceiveOffer", offerModel);
        }

        public async Task Visit(EventModel eventModel)
        {
            await _gameHubContext.Clients.All.SendAsync("ReceiveEvent", eventModel);
        }
    }
}
