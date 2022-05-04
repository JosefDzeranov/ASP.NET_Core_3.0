using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public void Add(User user)
        {
            users.Add(user);
        }

        public void Delete(Guid Id)
        {
            var user = TryGetById(Id);
            if(user != null)
            {
                users.Remove(user);
            }
            
        }

        public User TryGetById(Guid id)
        {
            return users.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
