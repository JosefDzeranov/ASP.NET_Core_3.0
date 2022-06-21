using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class InMemoryUserManager : IUsersManager
    {
        private readonly List<UserViewModel> users = new List<UserViewModel>();

        public List<UserViewModel> GetAll()
        {
            return users;
        }
        public void Add(UserViewModel user)
        {
            users.Add(user);
        }

        public UserViewModel TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.FirstName == name);
        }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void Remove(string id)
        {
            users.Remove(TryGetByName(id));
        }
        public void Edit(UserViewModel user)
        {
            var existingUser = TryGetByName(user.FirstName);
            existingUser.Phone = user.Phone;
            existingUser.Email = user.Email;
        }
    }
}
