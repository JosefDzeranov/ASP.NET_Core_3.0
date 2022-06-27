using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Common.Interface;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public sealed class DatabaseContext:DbContext
    {
        //private readonly IWorkWithData _productRepositoryJson = new JsonWorkWithData("projects_for_sale");
        //private readonly IProductRepository _productRepository;
        //доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<ComparisonProduct> ComparisonProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<UserDeleveryInfo> UserDeleveryInfo { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated(); //создаём БД при первом обращении

            //Добавляем продукты по умолчанию
            //_productRepository = new ProductDbRepository();
            //var productsJson = _productRepositoryJson.Read<List<Product>>();
            //foreach (var productJson in productsJson)
            //{
            //    _productRepository.AddNew(productJson);
            //}
        }



    }
}
