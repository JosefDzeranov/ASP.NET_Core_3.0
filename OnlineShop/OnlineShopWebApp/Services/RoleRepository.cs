using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class RoleRepository : IRoleRepository
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
            roles.RemoveAll(x=> x.Name == Name);
        }

        public Role TryGetByName(string Name)
        {
            return roles.FirstOrDefault(x => x.Name == Name);
        }
    }
}
