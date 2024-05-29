using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey((prop)=>prop.Id);
            builder.Property((prop)=>prop.Name).HasMaxLength(75).IsRequired();
            builder.Property((prop)=>prop.Description).HasMaxLength(250);
        }
    }
}