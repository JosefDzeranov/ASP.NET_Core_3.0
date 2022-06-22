using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

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

        void ChangePassword(ChangePassword data);
    }
}
