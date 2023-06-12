using GamePromotion.DAL.Entities;
using GamePromotion.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Infrastructure
{
    public class OfferRepository : IOfferRepository
    {
        private readonly MainContext _context;

        public OfferRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Offer>> GetAllOffers()
        {
            return await _context.offers.ToListAsync();
        }

        public async Task AddOffer(Offer offer)
        {
            await _context.offers.AddAsync(offer);
        }
    }
}
