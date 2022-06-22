using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated(); //создаем базу данных при первом обращении
        }

        /// <summary>
        ////Доступ к таблицам
        /// </summary>
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> Items { get; set; }

        public DbSet<FavoriteProduct> FavoriteProduct { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<UserDeliveryInfo> UserDelivery { get; set; }
    }
}
