using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Image> Image { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            var product1Id = 1;
            var product2Id = 2;
            var product3Id = -3;
            var product4Id = -4;
            var product5Id = -5;
            var product6Id = -6;
            var product7Id = -7;
            var product8Id = -8;
            var product9Id = -9;
            var product10Id = -10;
            var product11Id = -11;
            var product12Id = -12;

            var image1 = new Image
            {
                Id=product1Id,
                Url = "/images/turkey.jpg",
                ProductId = product1Id
            };
            var image2 = new Image
            {
                Id = product2Id,
                Url = "/images/greece.jpg",
                ProductId = product2Id
            };
            var image3 = new Image
            {
                Id = product3Id,
                Url = "/images/bulgary.jpg",
                ProductId = product3Id
            };
            var image4 = new Image
            {
                Id = product4Id,
                Url = "/images/aruba.jpg",
                ProductId = product4Id
            };
            var image5 = new Image
            {
                Id = product5Id,
                Url = "/images/mexico.jpg",
                ProductId = product5Id
            };
            var image6 = new Image
            {
                Id = product6Id,
                Url = "/images/bali.jpg",
                ProductId = product6Id
            };
            var image7 = new Image
            {
                Id = product7Id,
                Url = "/images/egypt.jpg",
                ProductId = product7Id
            };
            var image8 = new Image
            {
                Id = product8Id,
                Url = "/images/uae.jpg",
                ProductId = product8Id
            };
            var image9 = new Image
            {
                Id = product9Id,
                Url = "/images/seyshels.jpg",
                ProductId = product9Id
            };
            var image10 = new Image
            {
                Id = product10Id,
                Url = "/images/jamaica.jpg",
                ProductId = product10Id
            };
            var image11 = new Image
            {
                Id = product11Id,
                Url = "/images/india.jpg",
                ProductId = product11Id
            };
            var image12 = new Image
            {
                Id = product12Id,
                Url = "/images/thailand.jpg",
                ProductId = product12Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4, image5, image6, image7, image8, image9,
                image10, image11, image12);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {

                new Product(product1Id, "Тур в Турцию", 50000,  "Тур в Турцию за 50000 рублей"),
                new Product(product2Id, "Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей"),
                new Product(product3Id,"Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей"),
                new Product(product4Id,"Тур на Арубу", 50000, "Тур на Арубу за 50000 рублей"),
                new Product(product5Id,"Тур в Мексику", 60000, "Тур в Мексику за 60000 рублей"),
                new Product(product6Id,"Тур на Бали", 45000, "Тур на Бали за 45000 рублей"),
                new Product(product7Id,"Тур в Египет", 50000, "Тур в Еипет за 50000 рублей"),
                new Product(product8Id,"Тур в ОАЭ", 60000, "Тур в ОАЭ за 60000 рублей"),
                new Product(product9Id,"Тур на Сейшельские острова", 45000, "Тур на Сейшельские острова за 45000 рублей"),
                new Product(product10Id,"Тур на Ямайку", 50000, "Тур на Мальдивские острова за 50000 рублей"),
                new Product(product11Id,"Тур в Индию", 60000, "Тур в Индию за 60000 рублей"),
                new Product(product12Id,"Тур в Таиланд", 45000, "Тур в Таиланд за 45000 рублей")

            });
        }
    }
}

