using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<Cart> GetAll()
        {
            return _databaseContext.Carts.ToList();
        }

        public Cart Find(string buyerLogin)
        {
            var carts = GetAll();
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
            _databaseContext.Carts.Add(cart);
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
                var product = _databaseContext.Products.FirstOrDefault(product => product.Id == productId);
                _databaseContext.Carts.
                    Where(x => x.BuyerLogin == buyerLogin).
                    ToList()[0].CartItems.
                    Add(new CartItem() { Count = 1, Id = new Guid(), Product = product, Cart = cart.Id});
            }
            Save();
            fullSumm(buyerLogin);
        }

        public void UpCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count++;
            Save();
            fullSumm(buyerLogin);
        }

        public void DownCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count--;
            Save();
            fullSumm(buyerLogin);
        }

        public void DeleteProductInCart(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.CartItems.RemoveAll(cartItem => cartItem.Product.Id == productId);
            Save();
            fullSumm(buyerLogin);
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
            Save();
            fullSumm(buyerLogin);
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
            _databaseContext.SaveChanges();
        }

        private void fullSumm(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            decimal sum = 0;
            foreach (var cartItem in cart.CartItems)
            {
                sum += cartItem.Count * cartItem.Product.Cost;
            }
            _databaseContext.Carts.Where(x => x.BuyerLogin == buyerLogin).ToList()[0].FullSumm = sum;
            Save();
        }
    }
}