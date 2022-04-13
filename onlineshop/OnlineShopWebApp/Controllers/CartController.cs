using Microsoft.AspNetCore.Mvc;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productsRepository;
        private readonly CartsRepository cartsRepository;
        private readonly Constants constants;


        public CartController(ProductsRepository productsRepository, CartsRepository cartsRepository, Constants constants)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
