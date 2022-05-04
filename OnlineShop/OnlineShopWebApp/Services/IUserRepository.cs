using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Services
{
    public interface IUserRepository
    {
        bool Add(User user);
        void Update(Guid id);
        void Delete(Guid id);
        User TryGetById(Guid id);
        User TryGetByEmail(string email);
        bool Auth(string username, string password, bool rememberMe);
    }
}
