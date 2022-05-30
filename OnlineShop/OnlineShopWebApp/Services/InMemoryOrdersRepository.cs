//using System.Collections.Generic;
//using OnlineShopWebApp.Models;
//using System.Linq;
//using OnlineShop.db;

//namespace OnlineShopWebApp.Services
//{
//    public class InMemoryOrdersRepository : IOrdersRepository
//    {
//        private List<OrderViewModel> orders = new List<OrderViewModel>();

//        public void Add(OrderViewModel order)
//        {
//            orders.Add(order);
//        }

//        public List<OrderViewModel> GetAll()
//        {
//            return orders;
//        }

//        public OrderViewModel TryGetByUserId(int id)
//        {
//            return orders.FirstOrDefault(x => x.Id == id);
//        }

//        public void UpdateStatus(int orderId, OrderStatusViewModel newStatus)
//        {
//            var order = TryGetByUserId(orderId);
//            if (order != null)
//            {
//                order.Status = newStatus;
//            }
//        }
//    }
//}
