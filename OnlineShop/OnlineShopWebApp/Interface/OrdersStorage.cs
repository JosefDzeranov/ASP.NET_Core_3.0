using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders { get; set; } = new List<Order>();
        private List<Cart> carts = new List<Cart>();

        public Order TryGetOrderByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(string userId, string lastname, string name, string mail, string adress)
        {
            var LastOrderNumber = orders.FindLast(x => x.UserId == userId).OrderNumber;

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = LastOrderNumber++,
                OrderDate = DateTime.Now,
                UserId = userId,
                LastName = lastname,
                Name = name,
                Mail = mail,
                Address = adress,
                Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = Guid.NewGuid(),
                            Count = 1,
                        }
                    }
            };
            orders.Add(newOrder);
            RemoveAll();
        }

        public void RemoveAll()
        {
            carts.Clear();
        }

        //public void RemoveProduct(Product product, string userId)
        //{
        //    var existingCart = TryGetByUserId(userId);
        //    var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
        //    if (existingCartItem != null)
        //    {
        //        existingCart.Items.Remove(existingCartItem);
        //    }
        //}

        //public void RemoveCountProductCart(Product product, string userId)
        //{
        //    var existingCart = TryGetByUserId(userId);
        //    var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

        //    if (existingCartItem != null && existingCartItem.Count > 0)
        //    {
        //        if (existingCartItem.Count == 1)
        //            RemoveProduct(product, userId);
        //        else
        //            existingCartItem.Count -= 1;

        //    }
        //} 
    }
}
