using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Services
{
    public interface IOrderRepository
    {
        Task<List<Order>> TryGetByUserIdAsync(string userId);
        Task<List<Order>> TryGetAllAsync();
        Task AddAsync(Order order);
        Task UpdateStatusAsync(Guid orderId, OrderStatus status);
        Task<Order> TryGetByIdAsync(Guid Id);
    }
}
