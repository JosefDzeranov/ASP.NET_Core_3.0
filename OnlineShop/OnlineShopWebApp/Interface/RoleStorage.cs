using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class RoleStorage : IRoleStorage
    {
        private List<Role> roles = new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public void Remove(string Name)
        {
            roles.RemoveAll(x => x.Name == Name);
        }

        public Role TryGet(string Name)
        {
            return roles.FirstOrDefault(x => x.Name == Name);
        }
    }
}