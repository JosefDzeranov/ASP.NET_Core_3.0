using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductServicies _productServicies;
        private readonly ICartServicies _cartServicies;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CartController(IProductServicies productServicies, ICartServicies cartServicies, UserManager<User> userManager, IMapper mapper)
        {
            _productServicies = productServicies;
            _cartServicies = cartServicies;
            _userManager = userManager;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var cart = _cartServicies.TryGetByUserId(existingUser.Id);
            var cartViewModel = _mapper.Map<CartViewModel>(cart);
            return View(cartViewModel);
                
        }


        public IActionResult Add(int productId)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var product = _productServicies.AllProducts().FirstOrDefault(x => x.Id == productId);
            _cartServicies.Add(product, existingUser.Id);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            _cartServicies.DecreaseAmount(productId, existingUser.Id);
            return RedirectToAction("Index");
        }


    }
}
