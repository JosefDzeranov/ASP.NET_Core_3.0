using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersRepository
    {
        List<UserAccount> GetAll();
        UserAccount TryGetByLogin(string login);
        void Add(UserAccount newUser);
        void ChangePassword(NewPassword newPassword);
        void Edit(UserAccount userChange, string oldLogin);
        void Delete(string login);
    }
}
