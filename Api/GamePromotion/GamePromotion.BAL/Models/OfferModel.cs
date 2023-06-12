using GamePromotion.BAL.Enums;
using GamePromotion.BAL.Models.Abstractions;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Models
{
    public class OfferModel : ModelBase, IPromotion
    {
        public int Id { get; set; }
        public OfferTypes OfferType { get; set; }

        public async Task Accept(IPromotionVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
