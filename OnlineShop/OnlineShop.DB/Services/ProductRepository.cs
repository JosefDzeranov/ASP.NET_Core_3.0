using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDB.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public ProductRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await onlineShopContext.Products.ToListAsync();
        }

        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await onlineShopContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task DeleteAsync(Product product)
        {
            onlineShopContext.Products.Remove(product);
            var productInCart = await onlineShopContext.CartItems.FirstOrDefaultAsync(x => x.Product.Id == product.Id);
            if (productInCart != null)
            {
                onlineShopContext.CartItems.Remove(productInCart);
            }

            await onlineShopContext.SaveChangesAsync();
        }

        public async Task AddAsync(Product product)
        {
            await onlineShopContext.Products.AddAsync(product);
            await onlineShopContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {

            onlineShopContext.Products.Update(product);
            await onlineShopContext.SaveChangesAsync();
        }
    }
}
