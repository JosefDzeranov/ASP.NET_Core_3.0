using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductDataSource productDataSource; 
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductDataSource productDataSource, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productDataSource = productDataSource;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View(); 
        }
        [HttpPost]

        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name)!=null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }

        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles"); 
        }

        public IActionResult Products()
        {
            return View(productDataSource.GetAllProducts());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.AddProduct(product);
                return RedirectToAction("Products");
            }

            return View(product);
        }

        public IActionResult RemoveProduct(int productId)
        {
            productDataSource.RemoveProduct(productId);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            return View(product);
        }

        [HttpPost]

        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.EditProduct(product);
                return RedirectToAction("Products");
            }
            return View(product);
        }

        public IActionResult OrderDetails(int orderId)
        {
            var order = ordersRepository.TryGetByUserId(orderId);
            return View(order);
        }

        public IActionResult UpdateOrderStatus (int orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders"); 
        }
    }
}
