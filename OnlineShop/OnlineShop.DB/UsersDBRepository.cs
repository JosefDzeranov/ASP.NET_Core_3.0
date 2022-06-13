using Microsoft.AspNetCore.Identity;
using OnlineShop.Db;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB
{
    public class UsersDBRepository : IUserBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersDBRepository(DatabaseContext databaseContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IEnumerable<User> AllUsers()
        {
            var users = _userManager.Users.Where(x => !x.UserName.Contains("admin"));
            //if (users.Any())
            //{
            return users;
            //}
            //else
            //{
            //    var newUser = new User() { UserName = "Firokikidreamtek" };
            //    _userManager.Users.Add(newUser);
            //    _databaseContext.SaveChanges();
            //    return _databaseContext.Users;
            //}
        }



        public User TryGetById(string userId)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == userId);
        }

        //public void NewPassword(NewPassword newPassword)
        //{
        //    users.FirstOrDefault(x => x.Id == newPassword.UserId).Password = newPassword.Password;
        //    UpdateData();
        //}

        public void Delete(string userId)
        {
            //_userManager.Users.R(TryGetById(userId));
            //_databaseContext.SaveChanges();
        }

        public void Edit(User user)
        {
            var userForEdit = TryGetById(user.Id);
            userForEdit.Login = user.Login;
            userForEdit.LastName = user.LastName;
            userForEdit.FirstName = user.FirstName;
            userForEdit.PhoneNumber = user.PhoneNumber;
            _databaseContext.SaveChanges();
        }

        public void Add(User user)
        {
            //user.PhoneNumber = "Please, fill this field";
            //_databaseContext.Users.Add(user);
            //_databaseContext.SaveChanges();

        }
    }
}






