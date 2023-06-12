using GamePromotion.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Repositories
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetAllOffers();
        Task AddOffer(Offer offer);
    }
}
