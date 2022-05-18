using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp
{
    public class BuyerManager : IBuyerManager
    {
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "buyers";
        private List<UserBuyer> buyers;

        public BuyerManager()
        {
            buyers = JsonStorage.Read<List<UserBuyer>>();
        }

        public void AddProductInCart(Product product, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.AddProductInCart(product);
            JsonStorage.Write(buyers);
            
        }

        public void DeleteProductInCart(Guid productId, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.DeleteProductInCart(productId);
            JsonStorage.Write(buyers);
        }

        public void ReduceDuplicateProductCart(Guid productId, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.ReduceDuplicateProductCart(productId);
            JsonStorage.Write(buyers);
        }

        public void ClearCart(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.ClearCart();
            JsonStorage.Write(buyers);
        }

        public void SaveInfoBuying(InfoBuying infoBuying, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.SaveInfoBuying(infoBuying);
            JsonStorage.Write(buyers);
        }

        public void ClearInfoBuying(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.InfoBuying = null;
            JsonStorage.Write(buyers);
        }

        public void Buy(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.Buy();
            JsonStorage.Write(buyers);
        }

        public UserBuyer FindBuyer(string buyerLogin)
        {
            var buyer = buyers.Find(x => x.Login == buyerLogin);
            return buyer;
        }

        public List<OrderItem> CollectAllOrders()
        {
            List<OrderItem> collectAllOrders = new List<OrderItem>();
            foreach (var buyer in buyers)
            {
                var orders = buyer.Orders;
                foreach (var order in orders)
                {
                    collectAllOrders.Add(order);
                }
            }
            return collectAllOrders;
        }

        public OrderItem FindOrderItem(Guid orderId)
        {
            foreach (var buyer in buyers)
            {
                var orders = buyer.Orders;
                foreach (var order in orders)
                {
                    if (order.Id == orderId)
                    {
                        return order;
                    }
                }
            }
            return null;
        }

        public void UpdateOrderStatus(OrderItem newOrder)
        {
            var order = FindOrderItem(newOrder.Id);
            order.Status = newOrder.Status;
            JsonStorage.Write(buyers);
        }
    }
}
