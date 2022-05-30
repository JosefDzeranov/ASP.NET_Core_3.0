using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; } = new Order();

        public Cart Cart { get; set; }

        public Customer Customer { get; set; } = new Customer();

    }
}