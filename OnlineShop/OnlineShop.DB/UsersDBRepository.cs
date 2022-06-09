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

        public UsersDBRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<User> AllUsers()
        {
            var users = _databaseContext.Users;
            if (users.Any())
            {
                return users;
            }
            else
            {
                var newUser = new User() { UserName = "Firokikidreamtek" };
                _databaseContext.Users.Add(newUser);
                _databaseContext.SaveChanges();
                return _databaseContext.Users;
            }
        }



        public User TryGetById(string userId)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Id == userId);
        }

        //public void NewPassword(NewPassword newPassword)
        //{
        //    users.FirstOrDefault(x => x.Id == newPassword.UserId).Password = newPassword.Password;
        //    UpdateData();
        //}

        public void Delete(string userId)
        {
            _databaseContext.Users.Remove(TryGetById(userId));
            _databaseContext.SaveChanges();
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
            user.PhoneNumber = "Please, fill this field";
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

        }
    }
}






