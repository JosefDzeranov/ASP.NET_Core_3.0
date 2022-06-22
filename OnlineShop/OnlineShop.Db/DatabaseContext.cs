using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfo { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("a604ee7e-aa0e-4ffc-b596-816570a9bc79");
            var product2Id = Guid.Parse("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd");
            var product3Id = Guid.Parse("e66f97c7-6414-423b-9589-8c92a964df62");
            var product4Id = Guid.Parse("ba082277-4b6f-4e86-a922-07353ce4ad13");

            var image1 = new Image
            {
                Id = Guid.Parse("7512a027-6c2b-44ec-9dc1-460dc630a1e0"),
                Url = "/img/stilllife.jpg",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                Id = Guid.Parse("d8591f3b-ab34-4b87-325d-08dag437cf17"),
                Url = "/img/portret.jpg",
                ProductId = product1Id
            };

            var image3 = new Image
            {
                Id = Guid.Parse("30245a9c-ee30-4ddc-b53d-8fa3v86f4f78"),
                Url = "/img/landscape.jpg",
                ProductId = product1Id
            };

            var image4 = new Image
            {
                Id = Guid.Parse("30245a9c-er40-4tdc-b53d-8fa3f86f4f80"),
                Url = "/img/abstraction.jpg",
                ProductId = product1Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id, "Still Life", 100, "Photography, 2000 x 3000 px, 4,5 Mb Tiff"), 
                new Product(product2Id, "Portret", 200, "Photography, 2000 x 3000 px, 4,8 Mb Tiff"), 
                new Product(product3Id, "Landscape", 300, "Photography, 2000 x 3000 px, 3,5 Mb Tiff"), 
                new Product(product4Id, "Abstraction", 400, "Photography, 2000 x 3000 px, 2,5 Mb Tiff"), 
            });
        }
    }
}
