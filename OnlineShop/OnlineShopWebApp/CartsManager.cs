using System;
using System.Collections.Generic;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class CartsManager : ICartsManager
    {
        private readonly IProductManager _productManager;
        private IWorkWithData jsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "carts";
        private List<Cart> carts = new List<Cart>();

        public CartsManager(IProductManager productManager)
        {
            _productManager = productManager;
            carts = jsonStorage.Read<List<Cart>>();
        }
        public List<Cart> GetAll()
        {
            return carts;
        }

        public Cart Find(string buyerLogin)
        {
            foreach (var cart in carts)
            {
                if (cart.BuyerLogin == buyerLogin)
                {
                    return cart;
                }
            }
            return null;
        }

        public void CreateCartBuyer(string buyerLogin)
        {
            Cart cart = new Cart()
            {
                BuyerLogin = buyerLogin
            };
            carts.Add(cart);
            Save();
        }

        public void AddProductInCart(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                UpCountInCartItem(productId, buyerLogin);
            }
            else
            {
                var product = _productManager.Find(productId);
                cart.CartItems.Add(new CartItem(product));
            }
            fullSumm(buyerLogin);
            Save();
        }

        public void UpCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count++;
            fullSumm(buyerLogin);
            Save();
        }

        public void DownCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count--;
            fullSumm(buyerLogin);
            Save();
        }

        public void DeleteProductInCart(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.CartItems.RemoveAll(cartItem => cartItem.Product.Id == productId);
            fullSumm(buyerLogin);
            Save();
        }

        public void ReduceDuplicateProductCart(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                DownCountInCartItem(productId, buyerLogin);
            }
            if (existingCartItem.Count <= 0)
            {
                cart.CartItems.Remove(existingCartItem);
            }
            fullSumm(buyerLogin);
            Save();
        }

        public void ClearCart(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.CartItems.Clear();
            Save();
        }

        public int SumAllProducts(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            int sum = 0;
            foreach (var prod in cart.CartItems)
            {
                for (int i = 0; i < prod.Count; i++)
                {
                    sum++;
                }
            }
            return sum;
        }

        public void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.UserDeleveryInfo = userDeleveryInfo;
            Save();
        }

        public void ClearInfoBuying(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.UserDeleveryInfo = null;
            Save();
        }

        private void Save()
        {
            jsonStorage.Write(carts);
        }

        private void fullSumm(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            decimal sum = 0;
            foreach (var cartItem in cart.CartItems)
            {
                sum += cartItem.Count * cartItem.Product.Cost;
            }
            cart.FullSumm = sum;
            Save();
        }
    }
}