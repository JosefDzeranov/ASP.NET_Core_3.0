using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // access to Tables
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DataBaseContext(DbContextOptions <DataBaseContext> options)
            : base(options)
        {
            Database.Migrate(); // creates data table with the first call
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product("Name1",10,"Desc1","/images/item1.jpg"),
                new Product("Name2",20,"Desc1","/images/item2.jpg"),
                new Product("Name3",30,"Desc1","/images/item3.jpg"),
                new Product("Name4",40,"Desc1","/images/item4.jpg"),
                new Product("Name5",50,"Desc1","/images/item5.jpg"),
                new Product("Name6",60,"Desc1","/images/item6.jpg"),
            });
        }
    }
}
