using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.ViewModels
{
    public class OrderCartViewModel
    {
        public OrderViewModel Order { get; set; } = new OrderViewModel();
        public CartViewModel Cart { get; set; }


    }
}
