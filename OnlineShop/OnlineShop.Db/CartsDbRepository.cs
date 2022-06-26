using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _databaseContext.Carts
                .Include(c => c.CartItems)
                .Include(u => u.UserDeleveryInfo)
                .ToList();
        }

        public Cart Find(string buyerLogin)
        {
            var cart = _databaseContext.Carts
                .Include(cart => cart.UserDeleveryInfo) // подтянуть данные из таблицы UserDeleveryInfo
                .Include(cart => cart.CartItems)
                .ThenInclude(CartItem => CartItem.Product)
                .FirstOrDefault(Cart => Cart.BuyerLogin == buyerLogin);
            return cart;
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

        public void AddProduct(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var product = _databaseContext.Products.Find(productId);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Count++;
            }
            else
            {
                cart.CartItems.Add(new CartItem()
                {
                    Product = product,
                    Count = 1
                });
            }
            Save();
        }

        public void UpCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count++;
            Save();
        }

        public void DownCountInCartItem(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            var existingCartItem = cart.CartItems.Find(x => x.Product.Id == productId);
            existingCartItem.Count--;
            Save();
        }

        public void DeleteProductInCart(Guid productId, string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.CartItems.RemoveAll(cartItem => cartItem.Product.Id == productId);
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
            Save();
        }

        public void ClearCart(string buyerLogin)
        {
            var cart = Find(buyerLogin);
            cart.CartItems = null;
            Save();
        }

        public int QuantityAllProducts(string buyerLogin)
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

            cart.UserDeleveryInfo = 
                new UserDeleveryInfo()
                {
                    Commentary = userDeleveryInfo.Commentary,
                    Email = userDeleveryInfo.Email,
                    Firstname = userDeleveryInfo.Firstname,
                    Phone = userDeleveryInfo.Phone,
                    Secondname = userDeleveryInfo.Secondname,
                    Surname = userDeleveryInfo.Surname
                };
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
    }
}