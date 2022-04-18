using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IOrdersRepozitory
    {
        public void Add(Cart cart);
    }
}
