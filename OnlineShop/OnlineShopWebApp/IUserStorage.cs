using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp
{
    public interface IUserStorage
    {
        void Add(SignupViewModel signup);
        User TryGetById(Guid id);
        List<User> GetAll();
        bool Authorize(SigninViewModel signin);
        void ChangePassword(ChangePassword data);
        void Edit(User user);
        void Remove(Guid id);
    }
}
