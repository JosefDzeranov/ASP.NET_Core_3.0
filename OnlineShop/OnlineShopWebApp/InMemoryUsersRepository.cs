using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public UserAccount TryGetByLogin(string login)
        {
            return users.FirstOrDefault(x => x.Login == login);
        }
        public void Add(UserAccount newUser)
        {
            users.Add(newUser);
        }

        public void ChangePassword(NewPassword newPassword)
        {
            var existingUser = TryGetByLogin(newPassword.Login);
            existingUser.Password = newPassword.Password;
        }

        public void Edit (UserAccount userChange, string oldLogin)
        {
            var existingUser = TryGetByLogin(oldLogin);
            existingUser.Name = userChange.Name;
            existingUser.Login = userChange.Login;
            existingUser.Age = userChange.Age;
            existingUser.Email = userChange.Email;
        }
        public void Delete(string name)
        {
            users.RemoveAll(x => x.Login == name);
        }

    }
}
