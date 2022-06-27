using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class OrdersDbRepositiry : IOrdersRepositiry
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ICartsRepository _cartsRepository;
        public OrdersDbRepositiry(DatabaseContext databaseContext, ICartsRepository cartsRepository)
        {
            _databaseContext = databaseContext;
            _cartsRepository = cartsRepository;
        }

        public void Add(Order order)
        {
            _databaseContext.Orders.Add(order);
            Save();
        }

        public List<Order> GetAll()
        {
            return _databaseContext.Orders
                .Include(c => c.CartItems)
                .Include(u => u.UserDeleveryInfo)
                .Include(ci => ci.CartItems).ThenInclude(p => p.Product)
                .ToList();
        }
        public Order Find(Guid orderId)
        {
            return _databaseContext.Orders
                .Include(order => order)
                .Include(order => order.CartItems)
                .ThenInclude(CartItem => CartItem.Product)
                .FirstOrDefault(Order => Order.Id == orderId);
        }

        public void Buy(string buyerLogin)
        {
            var cart = _cartsRepository.Find(buyerLogin);
            var cartItems = _databaseContext.Carts
                .Include(cart => cart.CartItems)
                .ThenInclude(CartItem => CartItem.Product)
                .FirstOrDefault(Cart => Cart.BuyerLogin == buyerLogin)
                .CartItems;
            var order = new Order()
            {
                UserDeleveryInfo = cart.UserDeleveryInfo,
                CartItems = cartItems,
                BuyerLogin = buyerLogin
            };
            _databaseContext.Orders.Add(order);
            _cartsRepository.ClearCart(buyerLogin);
            
            Save();

            //    var cart = _cartsRepository.Find(buyerLogin);
            //    var orders = _databaseContext.Orders;
            //    var orderId = Guid.NewGuid();
            //    orders.Add(new Order()
            //    {
            //        BuyerLogin = buyerLogin,
            //        Id = orderId
            //    });
            //    Save();
            //    var cartInfoUsers = _databaseContext.Carts
            //        .Include(cart => cart.CartItems)
            //        .ThenInclude(CartItem => CartItem.Product)
            //        .FirstOrDefault(Cart => Cart.BuyerLogin == buyerLogin)
            //        .UserDeleveryInfo;
            //    var orderInfoUsers = _databaseContext.Orders.FirstOrDefault(Order => Order.Id == orderId).UserDeleveryInfo;
            //    orderInfoUsers = new UserDeleveryInfo()
            //    {
            //        Commentary = cartInfoUsers.Commentary,
            //        Firstname = cartInfoUsers.Firstname,
            //        Email = cartInfoUsers.Email,
            //        Phone = cartInfoUsers.Phone,
            //        Secondname = cartInfoUsers.Secondname,
            //        Surname = cartInfoUsers.Surname,
            //    };
            //    var cartItems = _databaseContext.Carts
            //        .Include(cart => cart.CartItems)
            //        .ThenInclude(CartItem => CartItem.Product)
            //        .FirstOrDefault(Cart => Cart.BuyerLogin == buyerLogin)
            //        .CartItems;
            //    var orderItems = _databaseContext.Orders.FirstOrDefault(Order => Order.Id == orderId).CartItems;
            //    orderItems = new List<CartItem>();

            //    foreach (var cartItem in cartItems)
            //    {
            //        orderItems.Add(new CartItem()
            //        {
            //            Count = cartItem.Count,
            //            Id = cartItem.Id,
            //            Product = cartItem.Product
            //        });
            //    }
            //    Save();
            //    cart.CartItems.Clear();
            //    Save();

        }


        public List<Order> CollectAllOrders(string buyerLogin)
        {
            List<Order> collectAllOrders = new List<Order>();
            var orders = _databaseContext.Orders.ToList();
            foreach (var order in orders)
            {
                if (order.BuyerLogin == buyerLogin)
                {
                    collectAllOrders.Add(order);
                }
            }
            return collectAllOrders;
        }

        public void UpdateOrderStatus(Order newOrder)
        {
            var order = Find(newOrder.Id);
            order.Status = newOrder.Status;
            Save();
        }

        private void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}