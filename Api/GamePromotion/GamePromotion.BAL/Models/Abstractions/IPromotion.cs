using System;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Models.Abstractions
{
    public interface IPromotion
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime StartsAt { get; set; }
        DateTime ExpiresAt { get; set; }
        Task Accept(IPromotionVisitor visitor);
    }
}
