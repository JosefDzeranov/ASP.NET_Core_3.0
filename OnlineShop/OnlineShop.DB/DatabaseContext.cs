using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(-1,"Лён однотонный, голубой",
                            610,
                            "Ширина 135 см, Плотность от 239 г/м2, Состав: вискоза - 60%, лён - 30%, хлопок - 10%, Производитель - Китай",
                            "/img/linen_blue.jpg"),
                new Product(-2,"Кашемировый трикотаж, фиолетовый",
                            4200,
                            "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            "/img/cashemir_vi.jpg"),
                new Product(-3,"Шёлк, бильярдный цвет",
                            2700,
                            "Ширина 135 см, Состав: шёлк - 100%, Производитель - Италия",
                            "/img/Silk_green.jpg"),
                new Product(-4,"Кашемир, лиловый",
                            5700,
                            "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            "/img/cashemir_li.jpg")

            });
        }

    }
}