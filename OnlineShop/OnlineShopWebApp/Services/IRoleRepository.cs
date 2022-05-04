using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(string Name);
    }
}
