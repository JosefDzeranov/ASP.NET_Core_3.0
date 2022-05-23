using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
                productViewModels.Add(productViewModel);
            }
            return productViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            return productViewModel;
        }


    public static Product ToProduct(this ProductViewModel productViewModel)
        {
            var product = new Product
            {
                ImagePath = productViewModel.ImagePath,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description
            };
            return product;
        }

        public static BasketItemViewModel ToBasketItemViewModel(this BasketItem basketItem)
        {
            var basketItemViewModel = new BasketItemViewModel
            {
                Id = basketItem.Id,
                Product = basketItem.Product,
                Quantity = basketItem.Quantity
            };
            return basketItemViewModel;
        }

        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            var items = new List<BasketItemViewModel>();

            foreach(var item in basket.Items)
            {
                items.Add(item.ToBasketItemViewModel());
            }

            var basketViewModel = new BasketViewModel
            {
                Id =basket.Id,
                UserId = basket.UserId,
                Items = items
            };

            return basketViewModel;
        }
    }
}
