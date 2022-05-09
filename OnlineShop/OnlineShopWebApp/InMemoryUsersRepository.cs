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

        public void Delete(string name)
        {
            users.RemoveAll(x => x.Login == name);
        }

    }
}
