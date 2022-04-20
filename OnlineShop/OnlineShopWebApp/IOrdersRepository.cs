using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Cart cart, Order order)
    }
}
