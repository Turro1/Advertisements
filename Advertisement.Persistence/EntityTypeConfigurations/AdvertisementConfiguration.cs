using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Advertisements.Domain;

namespace Advertisements.Persistence.EntityTypeConfigurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(advertisement => advertisement.Id);
            builder.HasIndex(advertisement => advertisement.Id).IsUnique();
            builder.Property(advertisement => advertisement.Text).HasMaxLength(250);

        }
    }
}
