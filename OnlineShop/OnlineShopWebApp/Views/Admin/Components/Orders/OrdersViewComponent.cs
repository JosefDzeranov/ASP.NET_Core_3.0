using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Admin.Components.Orders
{
    public class OrdersViewComponent : ViewComponent
    {
        private readonly IOrderRepository orderRepository;

        public OrdersViewComponent(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IViewComponentResult Invoke()
        {
            var existingOrders = orderRepository.TryGetAll();
            
            return View("Orders", existingOrders);
        }
    }
}
