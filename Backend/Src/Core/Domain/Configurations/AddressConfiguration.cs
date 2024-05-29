

using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Domain.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey((prop)=>prop.Id);
            builder.Property((prop)=>prop.Detail).HasMaxLength(50).IsRequired();
            builder.Property((prop)=>prop.City).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.Region).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.Country).HasMaxLength(100).IsRequired();
            builder.Property((prop)=>prop.ZipCode);
            builder.Property((prop)=>prop.Username);
        }
    }
}