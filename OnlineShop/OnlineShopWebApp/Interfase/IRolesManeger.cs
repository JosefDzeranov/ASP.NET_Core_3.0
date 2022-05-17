using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IRolesManeger
    {
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Add(Role role);
        void Remove(string name);
    }
}
