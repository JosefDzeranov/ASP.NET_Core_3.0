using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DB.Services

{
    public class CartRepository : ICartRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public CartRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public async Task<Cart> TryGetByUserIdAsync(string userId)
        {
            return await onlineShopContext.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<Cart> TryGetByIdAsync(Guid Id)
        {
            return await onlineShopContext.Carts.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task AddAsync(Product product, string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Quantinity = 1
                        }
                    }
                };
                await onlineShopContext.Carts.AddAsync(newCart);

            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity += 1;

                }
                else
                {
                    var carItem = new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantinity = 1

                    };
                    await onlineShopContext.CartItems.AddAsync(carItem);
                    existingCart.Items.Add(carItem);

                }
                onlineShopContext.Carts.Update(existingCart);
            }

            await onlineShopContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            if (existingCart != null)
            {
                onlineShopContext.Carts.Remove(existingCart);
                await onlineShopContext.SaveChangesAsync();
            }

        }

        public async Task RemoveItemAsync(Guid productId, string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity -= 1;
                    if (existingCartItem.Quantinity == 0)
                    {
                        existingCart.Items.Remove(existingCartItem);
                    }
                    onlineShopContext.Carts.Update(existingCart);
                    await onlineShopContext.SaveChangesAsync();
                }
            }
            if (existingCart.Items.Count == 0)
            {
                onlineShopContext.Carts.Remove(existingCart);
                await onlineShopContext.SaveChangesAsync();
            }
        }


    }
}
