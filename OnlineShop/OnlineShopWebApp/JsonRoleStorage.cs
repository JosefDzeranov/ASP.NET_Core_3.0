using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class JsonRoleStorage:IRolesStorage
    {
        private readonly List<Role> roles = new List<Role>();
        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.First();
        }

        public Role Add(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x=>x.Name == name);
        }
    }
}
