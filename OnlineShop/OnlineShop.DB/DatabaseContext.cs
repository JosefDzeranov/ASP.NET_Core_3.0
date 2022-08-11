using Entities;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(new List<ProductEntity>()
            {
                new ProductEntity(-1,"Лён однотонный, голубой",
                            610,
                            "Ширина 135 см, Плотность от 239 г/м2, Состав: вискоза - 60%, лён - 30%, хлопок - 10%, Производитель - Китай",
                            "/img/linen_blue.jpg", 6),
                new ProductEntity(-2,"Кашемировый трикотаж, фиолетовый",
                            4200,
                            "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            "/img/cashemir_vi.jpg", 3),
                new ProductEntity(-3,"Шёлк, бильярдный цвет",
                            2700,
                            "Ширина 135 см, Состав: шёлк - 100%, Производитель - Италия",
                            "/img/Silk_green.jpg", 8),
                new ProductEntity(-4,"Кашемир, лиловый",
                            5700,
                            "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            "/img/cashemir_li.jpg", 9)

            });
        }

    }
}