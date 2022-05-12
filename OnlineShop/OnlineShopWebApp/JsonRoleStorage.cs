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
        private List<Role> roles = new List<Role>();
        private const string nameSave = "Data/roles.json";

        public JsonRoleStorage()
        {
            ReadToStorage();
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
            WriteToStorage();
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x=>x.Name == name);
            WriteToStorage();
        }

        public string WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(roles, Formatting.Indented);
            File.WriteAllText(nameSave, json);
            return json;
        }

        private void ReadToStorage()
        {
            try
            {
                var json = File.ReadAllText(nameSave);
                roles = JsonConvert.DeserializeObject<List<Role>>(json);
            }
            catch (FileNotFoundException)
            {
                roles = new List<Role>();
            }
        }
    }
}
