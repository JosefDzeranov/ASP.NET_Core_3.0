using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRolesManager
    {
        public List<Role> Roles { get; }

        public void AddRole(Role role);

        public void RemoveRole(string name);

        public Role TryFindByName(string name);



    }

}



