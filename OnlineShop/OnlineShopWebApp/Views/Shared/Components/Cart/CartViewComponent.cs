using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartServicies _cartServicies;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public CartViewComponent(ICartServicies cartServicies, UserManager<User> userManager, IMapper mapper = null)
        {
            _cartServicies = cartServicies;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            if(userName == null)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.UserName.Contains("user"));
                var cart = _cartServicies.TryGetByUserId(user.Id);
                var ProductViewModelCounts = _mapper.Map<CartViewModel>(cart)?.Amount ?? 0;
                return View("Cart", ProductViewModelCounts);
            }
            else
            {
                var cart = _cartServicies.TryGetByUserName(userName);
                var ProductViewModelCounts = _mapper.Map<CartViewModel>(cart)?.Amount ?? 0;
                return View("Cart", ProductViewModelCounts);
            }
        }
    }
}
