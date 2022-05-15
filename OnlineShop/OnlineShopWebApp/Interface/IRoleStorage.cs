using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IRoleStorage
    {
        List<Role> GetAllRoles();
        Role TryGetByRole(string Name);
        void AddRole(Role role);
        void RemoveRole(string Name);
    }
}