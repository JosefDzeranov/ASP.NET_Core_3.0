using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp
{
    public class UsersManager : IUsersManager
    {
        string path = @"wwwroot\registredusers.json";

        private List<User> registredUsers = new List<User>();

        public void RegisterUser(Registration regInfo)
        {
            registredUsers = GetRegistredUsers();
            registredUsers.Add(new User(regInfo.Login, regInfo.Password));

            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public List<User> GetRegistredUsers()
        {
            string data = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    data = sr.ReadToEnd();
                }
                registredUsers = JsonConvert.DeserializeObject<List<User>>(data);
            }
            else
            {
                registredUsers = new List<User>();
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
