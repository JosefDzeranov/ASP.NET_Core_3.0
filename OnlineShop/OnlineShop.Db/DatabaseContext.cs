using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated(); //создаем базу данных при первом обращении

            Database.Migrate(); //миграция
            // если изменилась модель то надо в Package Manager Console добавить миграцию например командой --Add-Migration Initialization -context DatabaseContext--
            // где Initialization - имя миграции, DatabaseContext - имя контекста в рамках которой выполняется миграция. Сейчас контекст пока 1.
            //Add-Migration AddIdentityContext -context IdentityContext -OutputDir Migrations/Identity
            //--dotnet ef database update--context ConfigurationDbContext

            //dotnet ef migrations add InitConfigration -c Fully.Qualified.Namespaces.ConfigurationDbContext -o Migrations/Identity
            //dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext -o /Migrations/Identity

            //Unable to create an object of type 'IdentityContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product("Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд", "/images/court.jpg"),
                new Product("Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ", "/images/bankruptcy.jpg"),
                new Product("Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде", "/images/civil_case.jpg"),
                new Product("Консультация по вопросам", 3000, "Консультация по вопросам", "/images/law_consultation.jpg"),
                new Product("Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров", "/images/examination_documents.jpg")
            });

            modelBuilder.Entity<Product>().Property(p => p.Cost).HasColumnType("decimal(18,2)");
        }

        /// <summary>
        ////Доступ к таблицам
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart> CartItems { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<FavoriteProduct> FavoriteProduct { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserDeliveryInfo> UserDelivery { get; set; }
    }
}
