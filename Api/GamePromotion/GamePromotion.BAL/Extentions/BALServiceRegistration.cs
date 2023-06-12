using GamePromotion.BAL.Services;
using GamePromotion.BAL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GamePromotion.BAL.Extentions
{
    public static class BALServiceRegistration
    {
        public static IServiceCollection AddBALServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IEventService, EventService>();

            return services;
        }
    }
}
