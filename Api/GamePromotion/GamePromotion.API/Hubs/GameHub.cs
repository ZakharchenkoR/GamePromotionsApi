using GamePromotion.BAL.Models;
using GamePromotion.BAL.Models.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamePromotion.API.Hubs
{
    public class GameHub : Hub
    {
        private async Task BroadcastOffer(OfferModel offer)
        {
            await Clients.All.SendAsync("ReceiveOffer", offer);
        }

        private async Task BroadcastEvent(EventModel evnt)
        {
            await Clients.All.SendAsync("ReceiveEvent", evnt);
        }
    }
}
