
using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.Property((prop)=>prop.Detail).HasMaxLength(50).IsRequired();
            builder.Property((prop)=>prop.City).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.Region).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.Country).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.ZipCode);
            builder.Property((prop)=>prop.Username);
        }
    }
}