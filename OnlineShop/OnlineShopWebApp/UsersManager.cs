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

        private List<UserViewModel> registredUsers = new List<UserViewModel>();

        public void RegisterUser(Registration regInfo)
        {
            registredUsers = GetRegistredUsers();
            registredUsers.Add(new UserViewModel(regInfo.Login, regInfo.Password));

            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public void SaveNewUser(UserViewModel user)
        {
            if (registredUsers != null)
            {
                registredUsers = GetRegistredUsers();
            }
            else
            {
                registredUsers = new List<UserViewModel>();
            }

            registredUsers.Add(user);

            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public List<UserViewModel> GetRegistredUsers()
        {
            string data = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    data = sr.ReadToEnd();
                }
                registredUsers = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            else
            {
                registredUsers = new List<UserViewModel>();
            }

            return registredUsers;
        }

        public UserViewModel GetUserById(Guid id)
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

        public void EditUser(UserViewModel editedUser)
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
                    user.ConfirmedPassword = editedUser.ConfirmedPassword;
                }
            }
            var jsonData = JsonConvert.SerializeObject(registredUsers);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }

        public void DeleteUser(UserViewModel deletedUser)
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
