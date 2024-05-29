

using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Domain.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey((prop)=>prop.Id);
            builder.Property((prop)=>prop.Username).HasMaxLength(50).IsRequired();
            builder.Property((prop)=>prop.Comment).HasMaxLength(250).IsRequired();
        }
    }
}