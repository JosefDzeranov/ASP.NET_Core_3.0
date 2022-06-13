using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp
{
    public class BuyerManager : IBuyerManager
    {
        private readonly IProductManager _productManager;
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "buyers";
        private List<UserBuyer> buyers;

        public BuyerManager(IProductManager productManager)
        {
            _productManager = productManager;
            buyers = JsonStorage.Read<List<UserBuyer>>();
        }

        #region Buyer
        public void AddBuyer(User user)
        {
            UserBuyer buyer = new UserBuyer() { Login = user.Login };
            buyers.Add(buyer);
            JsonStorage.Write(buyers);
        }

        public UserBuyer FindBuyer(string buyerLogin)
        {
            var buyer = buyers.Find(x => x.Login == buyerLogin);
            return buyer;
        }

        public void Remove(string login)
        {
            buyers?.RemoveAll(x => x.Login == login);
            JsonStorage.Write(buyers);
        }
        #endregion

        public void Buy(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.Orders.Add(new Order(buyer.Cart, buyer.Login, buyer.UserDeleveryInfo));
            buyer.Cart.Clear();
            JsonStorage.Write(buyers);
        }

        #region Cart
        public void AddProductInCart(Product product, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            var existingCartItem = buyer.Cart.Find(x => x.Product.Id == product.Id);
            if (existingCartItem != null)
            {
                existingCartItem.UpCount();
            }
            else
            {
                buyer.Cart.Add(new CartItem(product));
            }
            JsonStorage.Write(buyers);
        }

        public void DeleteProductInCart(Guid productId, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.Cart.RemoveAll(cartItem => cartItem.Product.Id == productId);
            JsonStorage.Write(buyers);
        }

        public void ReduceDuplicateProductCart(Guid productId, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);

            var existingCartItem = buyer.Cart.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.DownCount();
            }
            if (existingCartItem.Count <= 0)
            {
                buyer.Cart.Remove(existingCartItem);
            }
            JsonStorage.Write(buyers);
        }

        public void ClearCart(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.Cart.Clear();
            JsonStorage.Write(buyers);
        }
        #endregion

        #region Orders
        public Order FindOrderItem(Guid orderId)
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

        public List<Order> CollectAllOrders()
        {
            List<Order> collectAllOrders = new List<Order>();
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

        public void UpdateOrderStatus(Order newOrder)
        {
            var order = FindOrderItem(newOrder.Id);
            order.Status = newOrder.Status;
            JsonStorage.Write(buyers);
        }
        #endregion

        #region UserDeleveryInfo
        public void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.UserDeleveryInfo = userDeleveryInfo;
            JsonStorage.Write(buyers);
        }
        public void ClearInfoBuying(string buyerLogin)
        {
            var buyer = FindBuyer(buyerLogin);
            buyer.UserDeleveryInfo = null;
            JsonStorage.Write(buyers);
        }
        #endregion
        
    }
}
