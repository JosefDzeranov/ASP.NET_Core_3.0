using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        //access to tables of DB
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
          
            Database.EnsureCreated();
        }
    }
}
