using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRoleStorage
    {
        List<Role> GetAll();
        Role TryGet(string Name);
        void Add(Role role);
        void Remove(string Name);
    }
}