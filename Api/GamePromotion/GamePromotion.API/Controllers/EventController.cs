using GamePromotion.API.Common;
using GamePromotion.BAL.Models;
using GamePromotion.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamePromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IBroadcaster _broadcaster;

        public EventController(IEventService eventService, IBroadcaster broadcaster)
        {
            _eventService = eventService;
            _broadcaster = broadcaster;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _eventService.GetEvents();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEventModel evnt)
        {
            var result = await _eventService.AddEvent(evnt);
            if (result != null)
            {
                await _broadcaster.BroadcastPromotion(result);
            }
            return Ok(result);
        }
    }
}
