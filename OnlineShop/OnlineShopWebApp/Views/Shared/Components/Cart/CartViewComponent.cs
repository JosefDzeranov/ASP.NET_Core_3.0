using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent: ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var cartViewController = Mapping.ToCartViewModel(cart);
            var productsCount = cartViewController?.Amount ?? 0;

            return (productsCount == 0) ? View("EmptyCart", string.Empty) : View("Cart", productsCount);
        }
    }
}
