using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

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
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Оно",
                    Cost = 450,
                    Description = "Автор: Стивен Кинг Жанр: мистика, ужасы",
                    Pages = 1025,
                    ImagePath = "/images/products/king.jpg"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Мрачный жнец",
                    Cost = 350,
                    Description = "Автор: Терри Пратчетт Жанр: фэнтези",
                    Pages = 356,
                    ImagePath = "/images/products/terri.jpg"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Странник по звездам",
                    Cost = 300,
                    Description = "Автор: Джек Лондон Жанр: роман",
                    Pages = 332,
                    ImagePath = "/images/products/london.jpg"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Крутые наследнички",
                    Cost = 350,
                    Description = "Автор: Дарья Донцова Жанр: детектив",
                    Pages = 425,
                    ImagePath = "/images/products/don.jpg"
                }
            });
        }
    }
}