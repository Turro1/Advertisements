using Microsoft.EntityFrameworkCore;
using Advertisements.Application.Interfaces;
using Advertisements.Domain;
using Advertisements.Persistence.EntityTypeConfigurations;

namespace Advertisements.Persistence
{
    public class AdvertisementsDbContext : DbContext, IAdvertisementsDbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }

        public AdvertisementsDbContext(DbContextOptions<AdvertisementsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdvertisementConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
