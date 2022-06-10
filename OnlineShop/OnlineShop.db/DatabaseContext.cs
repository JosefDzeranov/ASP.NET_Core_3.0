using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet <Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }  
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        
        public DbSet<Order>Orders { get; set; }

        public DatabaseContext(DbContextOptions <DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
