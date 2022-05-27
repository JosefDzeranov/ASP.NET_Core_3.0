using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<ComparingProduct> ComparingProducts { get; set; }
        public DbSet<FavouriteProduct> FavouriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryInformation> DeliveryInformarions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}