using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.ViewModels
{
    public class OrderVM
    {
        public Order Order { get; set; } = new Order();
        public Cart Cart { get; set; }


    }
}
