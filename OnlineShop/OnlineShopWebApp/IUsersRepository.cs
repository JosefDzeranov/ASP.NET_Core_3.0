using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    interface IUsersRepository
    {
        List<User> GetAll();
        User TryGetByName(string name);
        void Add(User newUser); 
        void Delete(string name);
    }
}
