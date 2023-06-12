using System.Threading.Tasks;

namespace GamePromotion.BAL.Models.Abstractions
{
    public interface IPromotionVisitor
    {
        Task Visit(OfferModel offerModel);
        Task Visit(EventModel eventModel);
    }
}
