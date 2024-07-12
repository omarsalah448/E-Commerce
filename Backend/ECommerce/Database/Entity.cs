using ECommerce.Classes;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Database
{
    public class Entity : DbContext
    {
        public Entity(DbContextOptions<Entity> options) : base(options) { }

        public DbSet<Category> Categories;
        public DbSet<Company> Companies;
        public DbSet<Product> Products;
        public DbSet<Purchase> Purchases;
        public DbSet<User> Users;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().OwnsMany(p => p.Reviews);
            modelBuilder.Entity<Purchase>().OwnsMany(p => p.PurchaseProducts);
            modelBuilder.Entity<User>().OwnsOne(p => p.PhoneNumber);
            modelBuilder.Entity<User>().OwnsOne(p => p.Cart, pn =>
            {
                pn.OwnsMany(p => p.PurchaseProducts);
            });
        }
    }
}
