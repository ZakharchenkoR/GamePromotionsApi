using GamePromotion.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace GamePromotion.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainContext _context;
        public IOfferRepository OfferRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public UnitOfWork(MainContext context)
        {
            _context = context;
            OfferRepository = new OfferRepository(_context);
            EventRepository = new EventRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
