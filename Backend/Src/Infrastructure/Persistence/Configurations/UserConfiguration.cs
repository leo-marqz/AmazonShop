
using AmazonShop.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonShop.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property((prop)=>prop.Id).HasMaxLength(36);
            builder.Property((prop)=>prop.NormalizedUserName).HasMaxLength(90);
        }
    }
}