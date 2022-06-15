using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        //access to tables of DB
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Comparison> Comparisons { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {


            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
          {

              new Product
                {
                    Name = "Cheeseburger",
                    Cost = 5,
                    Description = "Just a cheeseburger"
                },
            new Product
            {
                Name = "Hamburger",
                Cost = 3,
                Description = "Just a hamburger"
            },
           new Product
            {
                Name = "Bigburger",
                Cost = 10,
                Description = "the biggest burger"
            }
        });
        }
    }
}
