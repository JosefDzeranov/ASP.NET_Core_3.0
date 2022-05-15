using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp
{
    public interface IUserStorage
    {
        void Add(SignUp signup);
        User TryGetById(Guid id);
        List<User> GetAll();
        bool Authorize(SignIn signin);
        void ChangePassword(Guid id, ChangePassword data);
        void Edit(User user);
        void Remove(Guid id);
    }
}
