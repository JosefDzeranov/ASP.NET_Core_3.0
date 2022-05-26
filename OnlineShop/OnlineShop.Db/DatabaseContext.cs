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
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //.Entity<Favourite>()
            //.HasMany(p => p.Products)
            //.WithMany(p => p.Favourites)
            //.UsingEntity(j => j.ToTable("FavouriteProducts"));

            modelBuilder.Entity<FavouriteProducts>()
            .HasKey(p => new { p.FavouriteId, p.ProductId });

            modelBuilder.Entity<FavouriteProducts>()
                .HasOne(fp => fp.Favourite)
                .WithMany(f => f.FavouriteProducts)
                .HasForeignKey(fp => fp.FavouriteId);

            modelBuilder.Entity<FavouriteProducts>()
                .HasOne(fp => fp.Product)
                .WithMany(p => p.FavouriteProducts)
                .HasForeignKey(fp => fp.ProductId);
        }
    }
}