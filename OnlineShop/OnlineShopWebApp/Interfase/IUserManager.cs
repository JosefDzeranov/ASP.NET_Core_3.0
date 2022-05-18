using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Users;

namespace OnlineShopWebApp.Interfase
{
    public interface IUserManager
    {
        List<User> GetAll();
        void Authorized(User user);
        string GetLoginAuthorizedUser();
        bool GettingAccess(string userLogin, string action, string controller, string area);

        User FindByLogin(string userLogin);

        void Add(User user);

        void Remove(string userLogin);
        void AssignRole(string userLogin, Guid roleId);
    }
}
