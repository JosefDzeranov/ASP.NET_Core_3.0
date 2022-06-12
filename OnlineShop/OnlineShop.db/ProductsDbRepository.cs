using OnlineShop.db.Models;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductDataSource
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        //      private List<Product> products = new List<Product>()
        //{
        //	new Product("Тур в Турцию", 50000, "Тур в Турцию за 50000 рублей", "/images/turkey.jpg"),
        //	new Product("Тур в Грецию", 60000, "Тур в Грецию за 60000 рублей", "/images/greece.jpg"),
        //	new Product("Тур в Болгарию", 45000, "Тур в Болгарию за 45000 рублей", "/images/bulgary.jpg"),
        //	new Product("Тур на Арубу", 50000, "Тур на Арубу за 50000 рублей", "/images/aruba.jpg"),
        //	new Product("Тур в Мексику", 60000, "Тур в Мексику за 60000 рублей", "/images/mexico.jpg"),
        //	new Product("Тур на Бали", 45000, "Тур на Бали за 45000 рублей", "/images/bali.jpg"),
        //	new Product("Тур в Египет", 50000, "Тур в Еипет за 50000 рублей", "/images/egypt.jpg"),
        //	new Product("Тур в ОАЭ", 60000, "Тур в ОАЭ за 60000 рублей", "/images/uae.jpg"),
        //	new Product("Тур на Сейшельские острова", 45000, "Тур на Сейшельские острова за 45000 рублей", "/images/seyshels.jpg"),
        //	new Product("Тур на Ямайку", 50000, "Тур на Мальдивские острова за 50000 рублей", "/images/jamaica.jpg"),
        //	new Product("Тур в Индию", 60000, "Тур в Индию за 60000 рублей", "/images/india.jpg"),
        //	new Product("Тур в Таиланд", 45000, "Тур в Таиланд за 45000 рублей", "/images/thailand.jpg")
        //};

        public IEnumerable<Product> GetAllProducts()
        {
            return databaseContext.Products.Where(p => p.IsActive);
        }

        public Product GetProductById(int id)
        {
            return databaseContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.IsActive = true;
            product.ImagePath = "/images/Aruba.jpg";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();

        }

        public void RemoveProduct(int Id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == Id);
            product.IsActive = false;
            databaseContext.SaveChanges();

        }

        public void EditProduct(Product product)
        {
            var existing = GetProductById(product.Id);
            existing.Name = product.Name;
            existing.Cost = product.Cost;
            existing.Description = product.Description;
            databaseContext.SaveChanges();
        }
    }
}
