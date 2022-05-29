using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DB
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
