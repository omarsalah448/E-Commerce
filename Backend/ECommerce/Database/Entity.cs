using ECommerce.Classes;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Database
{
    public class Entity : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public Entity(DbContextOptions<Entity> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().OwnsMany(p => p.Reviews);
            modelBuilder.Entity<Purchase>().OwnsMany(p => p.PurchaseProducts);
            modelBuilder.Entity<ApplicationUser>().OwnsOne(p => p.Cart, pn =>
            {
                pn.OwnsMany(p => p.PurchaseProducts);
            });
        }
    }
}
