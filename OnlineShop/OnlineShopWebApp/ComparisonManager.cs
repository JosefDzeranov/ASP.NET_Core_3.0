using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ComparisonManager : IComparison
    {
        public string UserId { get; set; } 
    
        public List<ProductViewModel> Products { get; } = new List<ProductViewModel>();

        
     
        public void AddProduct(ProductViewModel product)
        {
            Products.Add(product);
        }

        public List<ProductViewModel> GetProducts()
        {
            return Products;
        }

    }
}