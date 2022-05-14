using Microsoft.EntityFrameworkCore;
using System;

namespace OnlineShop.DB
{
    public class OnlineShopContext : DbContext
    {

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
