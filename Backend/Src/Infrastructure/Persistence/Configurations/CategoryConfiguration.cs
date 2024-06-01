using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property((prop)=>prop.Name).HasMaxLength(75).IsRequired();
            builder.Property((prop)=>prop.Description).HasMaxLength(250);

            builder.HasMany(category=>category.Products)
                   .WithOne(product=>product.Category)
                   .HasForeignKey(product=>product.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

        }
    }
}