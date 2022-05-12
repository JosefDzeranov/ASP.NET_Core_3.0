using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IRolesStorage
    {
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Add(string name);
        void Remove(string name);
    }
}
