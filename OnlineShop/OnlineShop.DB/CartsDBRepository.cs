using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB
{
    public class CartsDBRepository : ICartBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;

        public CartsDBRepository(DatabaseContext databaseContext, UserManager<User> userManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        public List<Cart> AllCarts()
        {
            return _databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).Where(x => x.IsDeleted == false).ToList();
        }

        public Cart TryGetByUserId(string userId)
        {
            return _databaseContext.Carts
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .AsNoTracking()
                .FirstOrDefault(x => x.UserId == userId);
        }

        public Cart TryGetByUserName(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var carts = _databaseContext.Carts.Where(x => x.IsDeleted == false)
                        .Include(x => x.Items)
                        .ThenInclude(x => x.Product);
            var necessaryCart = carts
                                .AsNoTracking()
                                .FirstOrDefault(x => x.UserId == user.Id);
            return necessaryCart;




        }

        public void Add(Product product, string userId)
        {
            var existingCart = AllCarts().FirstOrDefault(x => x.UserId == userId);
            if (existingCart != null)
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
                        Product = product,
                        Amount = 1,
                        Id = Guid.NewGuid()
                    });
                }
            }
            else
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
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                _databaseContext.Carts.Add(newCart);
            }
            _databaseContext.SaveChanges();
        }

        public void DecreaseAmount(int productId, string userId)
        {
            var existingCart = AllCarts().FirstOrDefault(x => x.UserId == userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCartItem.Amount > 0)
            {
                existingCartItem.Amount -= 1;
                if (existingCartItem.Amount == 0)
                {
                    existingCart.Items.Remove(existingCartItem);
                }
                _databaseContext.Carts.Update(existingCart);
                _databaseContext.SaveChanges();
                if (!existingCart.Items.Any())
                {
                    Delete(userId);
                }
            }
        }

        public void Delete(string userId)
        {
            var existingCart = AllCarts().FirstOrDefault(x => x.UserId == userId);
            if (existingCart != null)
            {
                existingCart.IsDeleted = true;
                _databaseContext.SaveChanges();
            }
        }
    }
}
