using System;
using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Domain.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey((prop)=>prop.Id);
            builder.Property((prop)=>prop.Name).HasMaxLength(100).IsRequired();
            builder.Property((prop) => prop.Description).HasMaxLength(250).IsRequired();
            builder.Property((prop)=>prop.Price).HasColumnType("decimal(10,2)");
            builder.Property((prop) => prop.Rating);
            builder.Property((prop) => prop.Vendor).HasMaxLength(200).IsRequired();
            builder.Property((prop)=>prop.Status).HasConversion<int>();
            
        }
    }
}