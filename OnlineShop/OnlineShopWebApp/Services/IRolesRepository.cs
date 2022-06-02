using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IRolesRepository
    {
        void Add(Role role);
        List<Role> GetAllProducts();
        void Remove(string name);
        Role TryGetByName(string name);
    }
}