using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersRepository
    {
        List<UserViewModel> GetAll();
        UserViewModel TryGetByLogin(string login);
        void Add(UserViewModel newUser);
        void ChangePassword(NewPassword newPassword);
        void Edit(UserViewModel userChange, string oldLogin);
        void Delete(string login);
    }
}
