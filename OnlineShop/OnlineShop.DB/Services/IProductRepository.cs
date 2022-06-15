using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.DB.Services
{
    public interface IProductRepository
    {
        Task<Product> TryGetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task DeleteAsync(Product product);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
