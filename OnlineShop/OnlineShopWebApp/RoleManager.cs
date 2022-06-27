using System;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Common.Interface;

namespace OnlineShopWebApp
{
    public class RoleManager : IRoleManager
    {
        private readonly List<Role> roles;
        private const string nameSave = "roles";
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);

        public RoleManager()
        {
            roles = JsonStorage.Read<List<Role>>();
        }
        public List<Role> GetAll()
        {
            return roles;
        }

        public Role Find(Guid roleId)
        {
            return roles.FirstOrDefault(x => x.Id == roleId);
        }

        public void Add(Role role)
        {
            roles.Add(role);
            JsonStorage.Write(roles);
        }

        public void Remove(Guid Id)
        {
            roles.RemoveAll(x => x.Id == Id);
            JsonStorage.Write(roles);
        }
    }
}
