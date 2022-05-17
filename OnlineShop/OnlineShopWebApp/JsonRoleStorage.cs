using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class JsonRoleStorage : IRolesStorage
    {
        private readonly List<Role> roles;
        private const string nameSave = "roles";
        public IWorkWithData JsonStorage { get; set; } = new JsonWorkWithData(nameSave);

        public JsonRoleStorage()
        {
            roles = JsonStorage.Read<List<Role>>();
        }
        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Add(Role role)
        {
            roles.Add(role);
            JsonStorage.Write(roles);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
            JsonStorage.Write(roles);
        }
    }
}
