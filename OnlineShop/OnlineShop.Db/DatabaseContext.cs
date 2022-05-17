using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // access to Tables

        public DataBaseContext(DbContextOptions <DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated(); // creates data table with the first call
        }
    }
}
