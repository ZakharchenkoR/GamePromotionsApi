using GamePromotion.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task AddEvent(Event evnt);
    }
}
