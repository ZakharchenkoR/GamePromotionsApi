using GamePromotion.DAL.Entities;
using GamePromotion.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly MainContext _context;

        public EventRepository(MainContext context)
        {
            _context = context;
        }

        public async Task AddEvent(Event evnt)
        {
            await _context.events.AddAsync(evnt);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.events.ToListAsync();
        }
    }
}
