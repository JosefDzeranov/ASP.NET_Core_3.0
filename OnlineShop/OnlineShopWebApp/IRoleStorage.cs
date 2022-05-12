using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRoleStorage
    {
        Role TryGetRoleByName(string name);
        List<Role> GetAll();
        void Add(string name);
        void Remove(string name);
        void Edit(string oldName, Role role);
    }
}