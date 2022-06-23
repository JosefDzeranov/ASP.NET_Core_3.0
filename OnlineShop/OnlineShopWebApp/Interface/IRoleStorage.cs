using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRoleStorage
    {
        List<Role> GetAll();
        Role TryGet(string Name);
        void AddRole(Role role);
        void DeleteRole(string Name);
    }
}