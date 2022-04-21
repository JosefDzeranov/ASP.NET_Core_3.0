using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Admin.Components.Users
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public ProductsViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            var products = productRepository.GetAll();

            return View("Products", products);
        }
    }
}
