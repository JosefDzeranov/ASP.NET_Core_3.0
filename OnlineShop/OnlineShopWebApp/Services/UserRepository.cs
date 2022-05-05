using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public bool Add(User user)
        {
            if (TryGetByEmail(user.Email) != null)
            {
                return false;
            }
            {
                users.Add(user);
                return true;
            }

        }

        public bool Auth(string username, string password, bool rememberMe)
        {
            var user = TryGetByEmail(username);

            if (user != null)
            {
               if(user.Password == password)
                {
                    user.RememberMe = rememberMe;
                    return true;
                }
            }

            return false;

        }

        public void Delete(Guid id)
        {
            var user = TryGetById(id);
            if (user != null)
            {
                users.Remove(user);
            }

        }

        public List<User> GetAll()
        {
            return users;
        }

        public User TryGetByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public User TryGetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
