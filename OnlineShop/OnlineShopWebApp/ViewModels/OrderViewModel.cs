using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; } = new Order();
        public CartViewModel Cart { get; set; }


    }
}
