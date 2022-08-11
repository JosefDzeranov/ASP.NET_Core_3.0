using Domains;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB
{
    public class CartsDBRepository : ICartBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;
        private readonly IProductBase _productDataBase;


        public CartsDBRepository(DatabaseContext databaseContext, UserManager<User> userManager, IProductBase productDataBase)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _productDataBase = productDataBase;
        }

        public IEnumerable<CartEntity> AllCarts()
        {
            return _databaseContext.Carts.Where(x => x.IsDeleted == false).Include(x => x.Items).ThenInclude(x => x.Product).AsNoTracking();
        }

        public CartEntity TryGetByUserId(string userId)
        {
            var carts = _databaseContext.Carts
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.UserId == userId);
            return carts;
        }

        public CartEntity TryGetByUserName(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var carts = _databaseContext.Carts.Where(x => x.IsDeleted == false).AsNoTracking();
            var necessaryCart = carts.FirstOrDefault(x => x.UserId == user.Id);
            return necessaryCart;
        }

        public void Add(ProductEntity product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingProduct = _productDataBase.TryGetById(product.Id);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == existingProduct.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItemEntity
                    {
                        Product = existingProduct,
                        Amount = 1,
                    });
                }
            }
            else
            {
                var newCart = new CartEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemEntity>
                    {
                        new CartItemEntity
                        {
                            Amount = 1,
                            Product = existingProduct
                        }
                    }
                };
                _databaseContext.Carts.Add(newCart);
            }
            _databaseContext.SaveChanges();
        }

        public void DecreaseAmount(int productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
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
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                existingCart.IsDeleted = true;
                _databaseContext.SaveChanges();
            }
        }
    }
}
