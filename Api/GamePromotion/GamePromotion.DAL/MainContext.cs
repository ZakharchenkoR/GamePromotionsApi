using GamePromotion.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamePromotion.DAL
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Offer> offers { get; set; }
        public DbSet<Event> events { get; set; }
    }
}
