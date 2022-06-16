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
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            var productId1 = Guid.Parse("484c735f-2b49-47da-a864-16a7235453ee");
            var productId2 = Guid.Parse("4b440c91-6c7d-4269-8654-5fe34b4089ae");
            var productId3 = Guid.Parse("c6fe4bbe-d224-4b64-98fd-570fa48fa26c");
            var productId4 = Guid.Parse("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e");

            var image1 = new Image
            {
                ImageId = Guid.Parse("484c735f-2b49-47da-a864-16a7235453eb"),
                Url = "/images/products/king.jpg",
                ProductId = productId1
            };

            var image2 = new Image
            {
                ImageId = Guid.Parse("4b440c91-6c7d-4269-8654-5fe34b4089ab"),
                Url = "/images/products/terri.jpg",
                ProductId = productId2
            };

            var image3 = new Image
            {
                ImageId = Guid.Parse("c6fe4bbe-d224-4b64-98fd-570fa48fa26b"),
                Url = "/images/products/london.jpg",
                ProductId = productId3
            };

            var image4 = new Image
            {
                ImageId = Guid.Parse("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3b"),
                Url = "/images/products/don.jpg",
                ProductId = productId4
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product
                {
                    Id = productId1,
                    Name = "Оно",
                    Cost = 450,
                    Description = "Автор: Стивен Кинг Жанр: мистика, ужасы",
                    Pages = 1025,
                },
                new Product
                {
                    Id = productId2,
                    Name = "Мрачный жнец",
                    Cost = 350,
                    Description = "Автор: Терри Пратчетт Жанр: фэнтези",
                    Pages = 356
                },
                new Product
                {
                    Id = productId3,
                    Name = "Странник по звездам",
                    Cost = 300,
                    Description = "Автор: Джек Лондон Жанр: роман",
                    Pages = 332
                },
                new Product
                {
                    Id = productId4,
                    Name = "Крутые наследнички",
                    Cost = 350,
                    Description = "Автор: Дарья Донцова Жанр: детектив",
                    Pages = 425
                }
            });
        }
    }
}