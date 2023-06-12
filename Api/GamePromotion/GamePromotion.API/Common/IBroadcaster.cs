using GamePromotion.BAL.Models.Abstractions;
using System.Threading.Tasks;

namespace GamePromotion.API.Common
{
    public interface IBroadcaster
    {
        Task BroadcastPromotion(IPromotion promotion);
    }
}
