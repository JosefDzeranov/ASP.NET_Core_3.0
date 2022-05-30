using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IUserRepository
    {
        bool Add(UserViewModel user);
        void Update(UserViewModel user);
        void Delete(Guid id);
        UserViewModel TryGetById(Guid id);
        UserViewModel TryGetByEmail(string email);
        bool Auth(string username, string password, bool rememberMe);
        List<UserViewModel> GetAll();
    }
}
