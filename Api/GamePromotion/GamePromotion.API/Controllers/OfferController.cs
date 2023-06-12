using GamePromotion.API.Common;
using GamePromotion.BAL.Models;
using GamePromotion.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamePromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IBroadcaster _broadcaster;

        public OfferController(IOfferService offerService, IBroadcaster broadcaster)
        {
            _offerService = offerService;
            _broadcaster = broadcaster;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _offerService.GetOffers();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOfferModel offer)
        {
            var result = await _offerService.AddOffer(offer);
            if(result != null)
            {
               await _broadcaster.BroadcastPromotion(result);
            }

            return Ok(result);
        }
    }
}
