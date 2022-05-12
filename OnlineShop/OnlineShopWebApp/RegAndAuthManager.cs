using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp
{
    public class RegAndAuthManager : IRegAndAuthManager
    {
        string path = @"wwwroot\registredusers.json";

        private List<Registration> registredUsers = new List<Registration>();

        public void Register(Registration regInfo)
        {
            registredUsers = GetRegistredUsers();
            registredUsers.Add(regInfo);

            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public List<Registration> GetRegistredUsers()
        {
            string data = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    data = sr.ReadToEnd();
                }
                registredUsers = JsonConvert.DeserializeObject<List<Registration>>(data);
            }
            else
            {
                registredUsers = new List<Registration>();
            }

            return registredUsers;
        }

        public bool Compare(Authorization authorization)
        {
            registredUsers = GetRegistredUsers();
            if (registredUsers.FirstOrDefault(x => x.Password == authorization.Password && x.Login == authorization.Login) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
