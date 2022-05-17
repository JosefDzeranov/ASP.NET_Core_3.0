using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IRolesManeger
    {
        List<Role> GetAll();
        Role TryGetByName(Guid roleId);
        void Add(Role role);
        void Remove(Guid Id);
    }
}
