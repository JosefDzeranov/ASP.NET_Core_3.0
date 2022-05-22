using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
   public class DataBaseContext : DbContext
    {
        //доступ к таблице. DbSet - это доступ к одной таблице
        public DbSet<Product> Products { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       
    }
}
