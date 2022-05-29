using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartManagerDB : ICartManager
    {
        private readonly DataBaseContext dataBaseContext;
        public CartManagerDB(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }


        public List<Cart> GetCarts()
        {
            return dataBaseContext.Carts.ToList();
        }

        public void AddProductToCart(string userId, Product product)
        {
            var cart = TryGetCartByUserID(userId);


            if (cart == null)
            {

                var newCart = new Cart
                {
                    UserId = userId

                };

                newCart.CartLines = new List<CartLine>
                {
                        new CartLine
                        {

                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }
                };


                dataBaseContext.Carts.Add(newCart);

            }
            else
            {
                var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
                if (cartLine != null)
                {
                    cartLine.Amount++;
                }
                else
                {
                    cart.CartLines.Add(new CartLine
                    {

                        Product = product,
                        Amount = 1,
                        Cart = cart
                    });
                    
                }

            }
            dataBaseContext.SaveChanges();

        }

        public void RemoveProductFromCart(string userId, Guid productId)
        {
            var cart = dataBaseContext.Carts.FirstOrDefault(x => x.UserId == userId);
            var cartLine = cart.CartLines.FirstOrDefault(x => x.Product.Id == productId);
            cartLine.Amount--;

            if (cartLine.Amount <= 0)
            {
                cart.CartLines.Remove(cartLine);
            }
            dataBaseContext.SaveChanges();

        }

        public void RemoveCartLines(Cart cart)
        {
            cart.CartLines.Clear();
            dataBaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var cart = TryGetCartByUserID(userId);
            dataBaseContext.Carts.Remove(cart);
            dataBaseContext.SaveChanges();
        }


        public Cart TryGetCartByUserID(string userId)
        {
            return dataBaseContext.Carts.Include(x => x.CartLines).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);

        }

        
    }

}
