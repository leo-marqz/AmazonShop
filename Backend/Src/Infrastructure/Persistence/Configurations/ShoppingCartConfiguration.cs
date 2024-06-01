using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasMany(cart=>cart.Items)
                   .WithOne(item=>item.ShoppingCart)
                   .HasForeignKey(item=>item.ShoppingCartId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}