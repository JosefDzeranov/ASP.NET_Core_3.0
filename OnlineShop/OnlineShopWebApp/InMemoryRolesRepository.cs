using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>();

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }
        public void Add(Role newRole)
        {
            roles.Add(newRole);
        }

        public void Delete(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
