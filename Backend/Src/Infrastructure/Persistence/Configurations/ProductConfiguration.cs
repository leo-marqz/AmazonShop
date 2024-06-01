using System;
using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property((prop)=>prop.Name).HasMaxLength(100).IsRequired();
            builder.Property((prop) => prop.Description).HasMaxLength(250).IsRequired();
            builder.Property((prop)=>prop.Price).HasColumnType("decimal(10,2)");
            builder.Property((prop) => prop.Rating);
            builder.Property((prop) => prop.Vendor).HasMaxLength(200).IsRequired();
            builder.Property((prop)=>prop.Status).HasConversion<int>();

            builder.HasMany(product=>product.Reviews)
                   .WithOne(review=>review.Product)
                   .HasForeignKey(review=>review.ProductId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
            
            builder.HasMany(product=>product.Images)
                   .WithOne(image=>image.Product)
                   .HasForeignKey(image=>image.ProductId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
            
        }
    }
}