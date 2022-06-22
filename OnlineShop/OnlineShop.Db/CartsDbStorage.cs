using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsDbStorage : ICartsStorage
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            var cart = databaseContext.Carts.Include(cart => cart.Items)
                                                 .ThenInclude(item => item.Product)
                                                 .FirstOrDefault(x => x.UserId == userId);
            return cart;
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                };
                newCart.Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Count = 1,
                            Product = product
                        }
                    };
                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Count += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Count = 1,
                        Product = product
                    });
                }
            }
            databaseContext.SaveChanges();
        }

        public void RemoveProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem != null)
            {
                existingCart.Items.Remove(existingCartItem);
            }
        }

        public void RemoveCountProductCart(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart != null)
            {
                var cartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);

                if (cartItem != null)
                {
                    cartItem.Count--;
                    if (cartItem.Count == 0)
                    {
                        existingCart.Items.Remove(cartItem);
                    }
                }
            }

            databaseContext.SaveChanges();
        }

        public void ClearCartUser(string userId)
        {
            var cart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(cart);
            databaseContext.SaveChanges();
        }
    }
}