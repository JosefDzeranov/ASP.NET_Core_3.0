using Newtonsoft.Json;
using OnlineShop.Db;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace OnlineShopWebApp
{
    public class OrdersDBRepository : IOrderBase
    {

        private readonly DatabaseContext _databaseContext;

        public OrdersDBRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int NextOrderId()
        {
            var allOrders = AllOrders();

            if(allOrders.Any())
            {
                return allOrders.Select(x => x.Id).Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<Order> AllOrders()
        {
            var orders = _databaseContext.Orders.ToList();
            if (orders.Any())
            {
                return orders;
            }
            else
            {
                var newListOfOrders = new List<Order>();
                return newListOfOrders;
            }
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var necessaryOrder = AllOrders().FirstOrDefault(x => x.Id == orderId);
            necessaryOrder.Status = status;
            _databaseContext.SaveChanges();
        }

        public void Add(Order order)
        {
            //_databaseContext.Carts.Remove(order.Cart);
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }
    }
}
