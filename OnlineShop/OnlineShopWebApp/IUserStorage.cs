using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IUserStorage
    {
        void AddUser(SignUp signup);
        User TryGetUserById(Guid id);
        List<User> GetAll();
        bool AuthorizeUser(SignIn signin);
        void EditUser(User user);
        void RemoveUser(Guid id);
    }
}
