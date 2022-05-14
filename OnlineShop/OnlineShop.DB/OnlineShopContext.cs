using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB
{
    public class OnlineShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
