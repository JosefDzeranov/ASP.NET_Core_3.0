using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class UserRepository : IUserRepository
    {
        private List<UserViewModel> users = new List<UserViewModel>();
        public bool Add(UserViewModel user)
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

        public void Delete(string id)
        {
            var user = TryGetById(id);
            if (user != null)
            {
                users.Remove(user);
            }

        }

        public List<UserViewModel> GetAll()
        {
            return users;
        }

        public UserViewModel TryGetByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public UserViewModel TryGetById(string id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(UserViewModel user)
        {
            var oldUser = TryGetById(user.Id);
            users.Remove(oldUser);
            users.Add(user); 
        }
    }
}
