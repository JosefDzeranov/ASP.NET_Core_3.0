using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsRepositoryDb : ICartsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CartsRepositoryDb(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return dataBaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
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
                        Amount=1,
                        Product=product,
                        Cart = newCart
                    }
                };
                dataBaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Amount =1,
                        Product = product,
                        Cart=existingCart
                    });
                }
            }

            dataBaseContext.SaveChanges();
        }
        public void Remove(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Amount -= 1;
            }
            if (existingCartItem.Amount==0)
            {
                existingCart.Items.Remove(existingCartItem);
            }

            dataBaseContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            dataBaseContext.Carts.Remove(existingCart);
            dataBaseContext.SaveChanges();
        }
    }
}
