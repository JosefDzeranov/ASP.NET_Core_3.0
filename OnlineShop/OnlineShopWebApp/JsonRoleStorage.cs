using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class JsonRoleStorage:IRolesStorage
    {
        private readonly List<Role> roles;
        private const string nameSave = "roles";
        public IWorkWithData JsonStorage { get; set; } = new JsonWorkWithData(nameSave);

        public JsonRoleStorage()
        {
            roles = JsonStorage.ReadToStorage<Role>();
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
            JsonStorage.WriteToStorage(roles);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x=>x.Name == name);
            JsonStorage.WriteToStorage(roles);
        }
    }
}
