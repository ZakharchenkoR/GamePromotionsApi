using GamePromotion.BAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetEvents();
        Task<EventModel> AddEvent(AddEventModel evnt);
    }
}
