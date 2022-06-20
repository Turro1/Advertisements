using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Advertisements.Application.Interfaces;

namespace Advertisements.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AdvertisementsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IAdvertisementsDbContext>(provider =>
            provider.GetService<AdvertisementsDbContext>());
            return services;
        }
    }
}
