using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.ViewModels
{
    public class OrderViewModel
    {
        public Models.OrderViewModel Order { get; set; } = new Models.OrderViewModel();

        public CartViewModel Cart { get; set; }

    }
}