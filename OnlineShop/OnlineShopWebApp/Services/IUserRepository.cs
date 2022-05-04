using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Services
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(Guid Id);
        void Delete(Guid Id);
        User TryGetById(Guid id);
    }
}
