using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IUsersManager
    {
        List<User> GetAll();
        void Authorized(UserAutorized user);
        string GetLoginAuthorizedUser();
        bool CheckingForAuthorization();

        User Find(string userLogin);

        void Add(UserRegistration userInput);

        void Remove(string login);
        void AssignRole(string userLogin, Guid roleId);

        void ChangePassword(string login, string password);
        void ChangeInfo(UserInfo userInfo);
        void Exit();
    }
}
