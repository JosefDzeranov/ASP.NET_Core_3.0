using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IRoleManager
    {
        List<Role> GetAll();
        Role Find(Guid roleId);
        void Add(Role role);
        void Remove(Guid Id);
    }
}
