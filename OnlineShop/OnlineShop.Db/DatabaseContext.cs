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
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product()
                {
                    Id=Guid.NewGuid(),
                    Name="Name1",
                    Cost=1000,
                    Description = "Description1",
                    ImagePath="/images/item1.jpg",
                },
                new Product()
                {
                    Id=Guid.NewGuid(),
                    Name="Name2",
                    Cost=2000,
                    Description = "Description2",
                    ImagePath="/images/item2.jpg",
                },
                new Product()
                {
                    Id=Guid.NewGuid(),
                    Name="Name3",
                    Cost=3000,
                    Description = "Description3",
                    ImagePath="/images/item3.jpg",
                },
                new Product()
                {
                    Id=Guid.NewGuid(),
                    Name="Name4",
                    Cost=4000,
                    Description = "Description4",
                    ImagePath="/images/item4.jpg",
                },
                new Product()
                {
                    Id=Guid.NewGuid(),
                    Name="Name5",
                    Cost=5000,
                    Description = "Description5",
                    ImagePath="/images/item5.jpg",
                },
                new Product()
                {
                    Id= Guid.NewGuid(),
                    Name="Name6",
                    Cost=6000,
                    Description = "Description6",
                    ImagePath="/images/item6.jpg",
                },

            }) ;
        }
    }
}
