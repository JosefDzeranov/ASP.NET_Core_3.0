using Newtonsoft.Json;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace OnlineShopWebApp
{
    public class UsersInMemoryRepository : IUserBase
    {
        System.Text.Json.JsonSerializerOptions jsonOption = new System.Text.Json.JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        private List<User> users;
        public UsersInMemoryRepository()
        {
            users = AllUsers();
        }

        public int NextUserId()
        {
            var maxIdProduct = AllUsers().Select(x => x.Id).Max();
            return maxIdProduct + 1;
        }
        public List<User> AllUsers()
        {
            using (StreamReader r = new StreamReader("Models/Users.json", Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<List<User>>(r.ReadToEnd()).ToList();
            }
        }

        public bool Authentification(Authorization authorization)
        {
            if (AllUsers().Any(x => x.Login == authorization.Name && x.Password == authorization.Password))
            {
                return true;
            }
            return false;
        }

        public User TryGetById(int userId)
        {
            return AllUsers().FirstOrDefault(x => x.Id == userId);
        }

        public void NewPassword(NewPassword newPassword)
        {
            users.FirstOrDefault(x => x.Id == newPassword.UserId).Password = newPassword.Password;
            UpdateData();
        }

        public void Delete(int userId)
        {
            var user = users.FirstOrDefault(x => x.Id == userId);
            users.Remove(user);
            UpdateData();
        }

        public void Edit(User user)
        {
            var userForEdit = users.FirstOrDefault(x => x.Id == user.Id);
            userForEdit.Login = user.Login;
            userForEdit.LastName = user.LastName;
            userForEdit.FirstName = user.FirstName;
            userForEdit.Phone = user.Phone;
            UpdateData();
        }

        public void Add(User user)
        {
            user.Id = NextUserId();
            user.Phone = "Please, fill this field";
            users.Add(user);
            UpdateData();
        }

        private void UpdateData()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(users, jsonOption);
            File.WriteAllText("Models/Users.json", json);
        }
    }
}






