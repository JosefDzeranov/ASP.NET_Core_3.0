using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System;
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

        public void SaveNewUser(User user)
        {
            if (registredUsers != null)
            {
                registredUsers = GetRegistredUsers();
            }
            else
            {
                registredUsers = new List<User>();
            }

            registredUsers.Add(user);

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

        public User GetUserById(Guid id)
        {
            registredUsers = GetRegistredUsers();
            return registredUsers.Find(x => x.Id == id);
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

        public void EditUser(User editedUser)
        {
            registredUsers = GetRegistredUsers();

            foreach (var user in registredUsers)
            {
                if (user.Id == editedUser.Id)
                {
                    user.Name = editedUser.Name;
                    user.LastName = editedUser.LastName;
                    user.Login = editedUser.Login;
                    user.Password = editedUser.Password;
                }
            }
            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public void DeleteUser(User deletedUser)
        {
            registredUsers = GetRegistredUsers();

            registredUsers.Remove(registredUsers.Find(x => x.Id == deletedUser.Id));

            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }
        }


    }


}
