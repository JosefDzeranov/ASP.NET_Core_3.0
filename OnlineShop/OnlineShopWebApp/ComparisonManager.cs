using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ComparisonManager : IComparison
    {

        public List<Product> Products { get; } = new List<Product>();


        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

    }
}