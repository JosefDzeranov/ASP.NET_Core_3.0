using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IUserStorage
    {
        //User TryGetByUserId(Guid id);

        void Add(SignUp signup);

        //void RemoveProduct(Product product, string userId);

        //void RemoveCartUser(string userId);

        //void RemoveCountProductCart(Product product, string userId);

        //void Add(SignUp signup);

        User TryGetUserById(Guid id);

        List<User> GetAll();

        bool Authorize(SignIn signin);

        void Edit(User user);

        void Remove(Guid id);
    }
}
