using GamePromotion.DAL.Infrastructure;
using GamePromotion.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamePromotion.DAL.Extentions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainContext>(options =>
                        options.UseNpgsql(configuration.GetSection("DatabaseSettings:ConnectionString").Value));

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
