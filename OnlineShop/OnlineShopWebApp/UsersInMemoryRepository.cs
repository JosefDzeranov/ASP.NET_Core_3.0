using Newtonsoft.Json;
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

        public int NextUserId()
        {
            var maxIdProduct = AllUsers().Select(x => x.Id).Max();
            return maxIdProduct + 1;
        }
        public IEnumerable<User> AllUsers()
        {
            using (StreamReader r = new StreamReader("Models/Users.json", Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<List<User>>(r.ReadToEnd());
            }
        }

        public User TryGetById(int userId)
        {
            return AllUsers().FirstOrDefault(x => x.Id == userId);
        }

        public void Add(User user)
        {
            user.Id = NextUserId();
            user.Phone = "Please, fill this field";
            var newListOfUser = AllUsers().Append(user);
            var json = System.Text.Json.JsonSerializer.Serialize(newListOfUser, jsonOption);
            File.WriteAllText("Models/products.json", json);
        }
    }
}






