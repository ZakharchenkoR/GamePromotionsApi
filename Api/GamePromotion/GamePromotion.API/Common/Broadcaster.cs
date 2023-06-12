using GamePromotion.API.Hubs;
using GamePromotion.BAL.Models.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamePromotion.API.Common
{
    public class Broadcaster : IBroadcaster
    {
        private readonly IPromotionVisitor _promotionVisitor;

        public Broadcaster(IPromotionVisitor promotionVisitor)
        {
            _promotionVisitor = promotionVisitor;
        }

        public async Task BroadcastPromotion(IPromotion promotion)
        {
            var broadcaster = _promotionVisitor;
             await promotion.Accept(broadcaster);
        }
    }
}
