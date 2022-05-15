using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class RoleStorage : IRoleStorage
    {
        private List<Role> roles = new List<Role>();
        public void AddRole(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAllRoles()
        {
            return roles;
        }

        public void RemoveRole(string Name)
        {
            roles.RemoveAll(x => x.Name == Name);
        }

        public Role TryGetByRole(string Name)
        {
            return roles.FirstOrDefault(x => x.Name == Name);
        }
    }
}