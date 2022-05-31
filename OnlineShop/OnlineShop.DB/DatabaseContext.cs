using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfo { get; set; }


    }
}