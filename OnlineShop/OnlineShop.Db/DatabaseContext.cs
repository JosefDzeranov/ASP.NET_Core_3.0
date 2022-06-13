using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // access to Tables
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataBaseContext(DbContextOptions <DataBaseContext> options)
            : base(options)
        {
            Database.Migrate(); // creates data table with the first call
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("31825d42-7a2c-4245-84a5-32f044df42eb");
            var product2Id = Guid.Parse("99b708a2-dcf2-4614-9a52-6c828bf3ef01");
            var product3Id = Guid.Parse("d93266b2-af1d-4d7b-abcf-7ff41138c8ad");
            var product4Id = Guid.Parse("dc3024e6-a030-4aff-8d2b-8a1b8c35c1d8");
            var product5Id = Guid.Parse("77e13cf3-2861-4c5f-9dfa-bde3eeb5eaf6");
            var product6Id = Guid.Parse("c6acbc3f-3429-4cb7-8242-c896feb0c8ea");

            var image1 = new Image
            {
                Id = Guid.Parse("ed104a21-5d13-43cf-86b6-dce052735bd5"),
                Url = "/images/Products/item1.png",
                ProductId = product1Id
            };
            var image2 = new Image
            {
                Id = Guid.Parse("1fcdb7e1-6c36-4d63-8d72-1de5f0be4c75"),
                Url = "/images/Products/item2.png",
                ProductId = product2Id
            };
            var image3 = new Image
            {
                Id = Guid.Parse("58a00580-f628-42c8-a32d-371a7adf85bc"),
                Url = "/images/Products/item3.png",
                ProductId = product3Id
            };
            var image4 = new Image
            {
                Id = Guid.Parse("baff13d6-da29-4a42-ad86-bf4ee29ec70b"),
                Url = "/images/Products/item4.png",
                ProductId = product4Id
            };
            var image5 = new Image
            {
                Id = Guid.Parse("3b0fed2c-8cbd-453f-93f4-90ff6c3ab7fb"),
                Url = "/images/Products/item5.png",
                ProductId = product5Id
            };
            var image6 = new Image
            {
                Id = Guid.Parse("29c149e1-553b-49b0-b106-6b0882a71745"),
                Url = "/images/Products/item6.png",
                ProductId = product6Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4, image5, image6);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id,"Name1",1000, "Description1"),
                new Product(product2Id,"Name2",2000, "Description2"),
                new Product(product3Id,"Name3",3000, "Description3"),
                new Product(product4Id,"Name4",4000, "Description4"),
                new Product(product5Id,"Name5",5000, "Description5"),
                new Product(product6Id,"Name6",6000, "Description6"),
            }) ;
        }
    }
}
