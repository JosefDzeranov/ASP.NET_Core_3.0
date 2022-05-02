using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using System.Collections.Generic;
using System.Linq;

public class RolesManager : IRolesManager
{
    public List<Role> Roles { get; } = new List<Role>();

    public void AddRole(Role role)
    {
        Roles.Add(role);
    }

    public void RemoveRole(string name)
    {
        var role = TryFindByName(name);
        Roles.Remove(role);
    }

    public Role TryFindByName(string name)
    {
        return Roles.FirstOrDefault(x => x.Name == name);
    }

   
}
