using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {

                new Product (-1, "Тур в Турцию", 50000,  "Тур в Турцию за 50000 рублей", "/images/turkey.jpg"),
                new Product(-2, "Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей", "/images/greece.jpg"),
                new Product(-3,"Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей", "/images/bulgary.jpg"),
                new Product(-4,"Тур на Арубу", 50000, "Тур на Арубу за 50000 рублей", "/images/aruba.jpg"),
                new Product(-5,"Тур в Мексику", 60000, "Тур в Мексику за 60000 рублей", "/images/mexico.jpg"),
                new Product(-6,"Тур на Бали", 45000, "Тур на Бали за 45000 рублей", "/images/bali.jpg"),
                new Product(-7,"Тур в Египет", 50000, "Тур в Еипет за 50000 рублей", "/images/egypt.jpg"),
                new Product(-8,"Тур в ОАЭ", 60000, "Тур в ОАЭ за 60000 рублей", "/images/uae.jpg"),
                new Product(-9,"Тур на Сейшельские острова", 45000, "Тур на Сейшельские острова за 45000 рублей", "/images/seyshels.jpg"),
                new Product(-10,"Тур на Ямайку", 50000, "Тур на Мальдивские острова за 50000 рублей","/images/jamaica.jpg"),
                new Product(-11,"Тур в Индию", 60000, "Тур в Индию за 60000 рублей", "/images/india.jpg"),
                new Product(-12,"Тур в Таиланд", 45000, "Тур в Таиланд за 45000 рублей", "/images/thailand.jpg")

            });
        }
    }
}

