using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public OrderRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public async Task AddAsync(Order order)
        {
            await onlineShopContext.Orders.AddAsync(order);
            await onlineShopContext.SaveChangesAsync();
        }

        public async Task<Order> TryGetByIdAsync(Guid Id)
        {
            return await onlineShopContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Order>> TryGetAllAsync()
        {
            return await onlineShopContext.Orders.ToListAsync();
        }

        public async Task<List<Order>> TryGetByUserIdAsync(string userId)
        {
            return await onlineShopContext.Orders.Where(x => x.UserId == userId).ToListAsync();

        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus status)
        {

            var order = await TryGetByIdAsync(orderId);
            order.Status = status;
            onlineShopContext.Orders.Update(order);
            await onlineShopContext.SaveChangesAsync();
        }

       
    }
}
