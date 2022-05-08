using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        List<User> users = new List<User>();

        public List<User> GetAll()
        {
            return users;
        }

        public User TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }
        public void Add(User newUser)
        {
            users.Add(newUser);
        }

        public void Delete(string name)
        {
            users.RemoveAll(x => x.Name == name);
        }

    }
}
