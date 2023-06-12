using System;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOfferRepository OfferRepository { get; }
        IEventRepository EventRepository { get; }
        Task SaveAsync();
    }
}
