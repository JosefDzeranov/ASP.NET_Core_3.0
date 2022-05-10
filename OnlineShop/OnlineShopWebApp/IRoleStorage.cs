using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRoleStorage
    {
        Role TryGetRoleByName(string name);
        List<Role> GetAll();
        void AddRole(string name);
        void RemoveRole(string name);
        void EditRole(string oldName, Role role);
    }
}