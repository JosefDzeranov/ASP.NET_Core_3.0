using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IUserStorage
    {
        void Add(SignupViewModel signup);

        User TryGetUserById(Guid id);

        List<User> GetAll();

        bool Authorize(SigninViewModel signin);

        void Edit(User user);

        void Remove(Guid id);

        void ChangePassword(ChangePassword data);
    }
}
