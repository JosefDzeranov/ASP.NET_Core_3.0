using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IUserStorage
    {
        void Add(SignUp signup);
        User TryGetUserById(Guid id);
        List<User> GetAll();
        bool Authorize(SignIn signin);
        void Edit(User user);
        void Remove(Guid id);
    }
}
