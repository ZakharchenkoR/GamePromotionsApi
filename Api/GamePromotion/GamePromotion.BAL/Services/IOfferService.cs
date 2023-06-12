using GamePromotion.BAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferModel>> GetOffers();
        Task<OfferModel> AddOffer(AddOfferModel offer);
    }
}
