using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class ProductManager : IProductManager
    {
        public List<Product> productList { get; set; } = new List<Product>
        {

               new Product(1, "Cheeseburger", 150, "бургер с говяжьей котлетой и сыром"),
               new Product(2, "Hamburger", 120, "бургер с говяжьей котлетой"),
               new Product(3, "Bigburger", 200, "бургер с двойной говяжьей котлетой")

        };

        public List<Product> AllProducts()
        {
            return productList;
        }

        public Product FindProduct(int id)
        {
            return productList.Find(product => product.Id == id);
        }

    }
}
