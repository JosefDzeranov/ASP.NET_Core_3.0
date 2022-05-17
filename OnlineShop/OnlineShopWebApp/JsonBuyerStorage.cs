using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp
{
    public class JsonBuyerStorage : IBuyerStorage
    {
        public IWorkWithData JsonStorage { get; set; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "list_of_buyers";
        private List<Buyer> buyers;

        public JsonBuyerStorage()
        {
            buyers = JsonStorage.Read<List<Buyer>>();
        }

        public void AddProductInCart(Product product, Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.AddProductInCart(product);
            JsonStorage.Write(buyers);
        }

        public void DeleteProductInCart(Guid productId, Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.DeleteProductInCart(productId);
            JsonStorage.Write(buyers);
        }

        public void ReduceDuplicateProductCart(Guid productId, Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.ReduceDuplicateProductCart(productId);
            JsonStorage.Write(buyers);
        }

        public void ClearCart(Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.ClearCart();
            JsonStorage.Write(buyers);
        }

        public void SaveInfoBuying(InfoBuying infoBuying, Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.SaveInfoBuying(infoBuying);
            JsonStorage.Write(buyers);
        }

        public void ClearInfoBuying(Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.infoBuying = null;
            JsonStorage.Write(buyers);
        }

        public void Buy(Guid buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.Buy();
            JsonStorage.Write(buyers);
        }

        public Buyer FindBuyer(Guid buyerId)
        {
            var buyer = buyers.Find(x => x.Id == buyerId);
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
