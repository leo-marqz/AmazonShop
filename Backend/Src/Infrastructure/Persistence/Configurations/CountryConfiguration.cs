using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property((prop)=>prop.Name).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.Iso2);
            builder.Property((prop)=>prop.Iso3);
        }
    }
}