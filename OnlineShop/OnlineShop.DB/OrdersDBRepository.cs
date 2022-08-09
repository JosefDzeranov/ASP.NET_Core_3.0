using Entities;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.DB;
using System.Collections.Generic;
using System.Linq;

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

            if (allOrders.Any())
            {
                return allOrders.Select(x => x.Id).Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<OrderEntity> AllOrders()
        {
            var orders = _databaseContext.Orders.Include(x => x.Items).ThenInclude(x => x.Product).Include(x => x.DeliveryInfo).ToList();
            if (orders.Any())
            {
                return orders;
            }
            else
            {
                var newListOfOrders = new List<OrderEntity>();
                return newListOfOrders;
            }
        }

        public void UpdateOrderStatus(int orderId, OrderStatusEntity status)
        {
            var necessaryOrder = AllOrders().FirstOrDefault(x => x.Id == orderId);
            necessaryOrder.Status = status;
            _databaseContext.SaveChanges();
        }

        public void Add(OrderEntity order)
        {
            _databaseContext.Entry(order).State = EntityState.Added;
            //_databaseContext.Entry(order.Items.FirstOrDefault()).State = EntityState.Modified;
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }
    }
}
