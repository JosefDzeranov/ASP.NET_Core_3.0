using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> Items { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
