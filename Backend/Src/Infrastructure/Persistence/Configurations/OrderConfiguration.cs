using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // One to One
            builder.OwnsOne((order)=>order.Address, (x)=>{
                x.WithOwner();
            });

            builder.HasMany(order=>order.Items)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(order=>order.Status)
                   .HasConversion(
                        (status)=>status.ToString(),
                        (status)=>(OrderStatus)Enum.Parse(typeof(OrderStatus), status)
                   );
        }
    }
}