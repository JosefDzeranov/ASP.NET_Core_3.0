using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
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
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product("/img/stilllife.jpg", "Still Life", 100, "Photography, 2000 x 3000 px, 4,5 Mb Tiff"), 
                new Product("/img/portret.jpg", "Portret", 200, "Photography, 2000 x 3000 px, 4,8 Mb Tiff"), 
                new Product("/img/landscape.jpg", "Landscape", 300, "Photography, 2000 x 3000 px, 3,5 Mb Tiff"), 
                new Product("/img/abstraction.jpg", "Abstraction", 400, "Photography, 2000 x 3000 px, 2,5 Mb Tiff"), 
                new Product("/img/test.jpg", "Test", 10, "Calibration image, 2000 x 3000 px, 2,4 Mb Tiff") 
            });
        }
    }
}
