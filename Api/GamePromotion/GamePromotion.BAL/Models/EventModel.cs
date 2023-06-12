using GamePromotion.BAL.Enums;
using GamePromotion.BAL.Models.Abstractions;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Models
{
    public class EventModel : ModelBase, IPromotion
    {
        public int Id { get; set; }
        public EventTypes EventType { get; set; }

        public async Task Accept(IPromotionVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
