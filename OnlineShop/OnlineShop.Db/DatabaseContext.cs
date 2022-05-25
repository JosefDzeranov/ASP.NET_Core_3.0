using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<FavouriteProducts> FavouriteProducts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favourite>(b =>
            {
                b
                .HasMany(a => a.Products)
                .WithMany(a => a.Favourites)
                .UsingEntity(e => { e.ToTable(""); });
            }
            );
        }
    }
}