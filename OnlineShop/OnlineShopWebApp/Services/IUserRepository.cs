using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IUserRepository
    {
        bool Add(User user);
        void Update(User user);
        void Delete(Guid id);
        User TryGetById(Guid id);
        User TryGetByEmail(string email);
        bool Auth(string username, string password, bool rememberMe);
        List<User> GetAll();
    }
}
