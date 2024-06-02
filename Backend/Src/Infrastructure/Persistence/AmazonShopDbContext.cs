
using System;
using System.Threading;
using System.Threading.Tasks;
using AmazonShop.Domain.Common;
using AmazonShop.Domain.Models;
using AmazonShop.Domain.Models.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmazonShop.Infrastructure.Persistence
{
    public class AmazonShopDbContext : IdentityDbContext<User>
    {
        public AmazonShopDbContext(DbContextOptions<AmazonShopDbContext> options) 
        : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken= default){
            var userName = "System";

            foreach (var entry in ChangeTracker.Entries<ModelBase>()){
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = userName;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateAt = DateTime.Now;
                        entry.Entity.UpdateBy = userName;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = userName;
                        entry.Entity.DeletedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AmazonShopDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}