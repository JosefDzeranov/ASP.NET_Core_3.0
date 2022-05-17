using System;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class RoleManeger : IRolesManeger
    {
        private readonly List<Role> roles;
        private const string nameSave = "roles";
        public IWorkWithData JsonStorage { get; set; } = new JsonWorkWithData(nameSave);

        public RoleManeger()
        {
            roles = JsonStorage.Read<List<Role>>();
        }
        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(Guid roleId)
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
