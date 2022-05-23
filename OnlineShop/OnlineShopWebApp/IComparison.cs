using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IComparison
    {
        public string UserId { get; set; }
        public List<ProductViewModel> Products { get; }
        public void AddProduct(ProductViewModel product);
        public List<ProductViewModel> GetProducts();
                
    }
}