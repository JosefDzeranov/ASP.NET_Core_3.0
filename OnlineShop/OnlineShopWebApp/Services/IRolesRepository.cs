using System.Collections.Generic;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp.Services
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string Name); 
        void Add(Role role);
        void Remove (string name);
    }
}
