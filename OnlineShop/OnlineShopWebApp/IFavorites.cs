using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IFavorites
    {
        public List<ProductViewModel> Products { get; }

        public void AddProduct(ProductViewModel product);


        public List<ProductViewModel> GetProducts();
        

    }
}