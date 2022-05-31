using OnlineShop.DB.Models;
using System;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public int Amount { get; set; }

        public decimal Cost
        {
            get { return ProductViewModel.Cost*Amount; }
        }

        public ProductViewModel ToDto(Product product)
        {
            ProductViewModel newProduct = new ProductViewModel();

            product.Cost = product.Cost;
            product.Description = product.Description;
            product.ImgPath = product.ImgPath;
            product.Name = product.Name;
            product.Id = product.Id;
            return newProduct;
        }
    }
}
