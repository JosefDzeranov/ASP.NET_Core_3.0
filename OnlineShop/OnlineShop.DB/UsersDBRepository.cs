using Newtonsoft.Json;
using OnlineShop.Db;
using OnlineShop.DB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OnlineShop.DB
{
    public class UsersDBRepository : IUserBase
    {
        private readonly DatabaseContext _databaseContext;

        public UsersDBRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<User> AllUsers()
        {
            var users = _databaseContext.Users.ToList();
            if (users.Any())
            {
                return users;
            }
            else
            {
                var newListOfUsers = new List<User>();
                newListOfUsers.Add(new User("Firokikidreamtek","+7-985-041-73-94", "11"));
                return newListOfUsers;
            }
        }



        public User TryGetById(int userId)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Id == userId);
        }

        //public void NewPassword(NewPassword newPassword)
        //{
        //    users.FirstOrDefault(x => x.Id == newPassword.UserId).Password = newPassword.Password;
        //    UpdateData();
        //}

        public void Delete(int userId)
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
            userForEdit.Phone = user.Phone;
            _databaseContext.SaveChanges();
        }

        public void Add(User user)
        {
            user.Phone = "Please, fill this field";
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

        }
    }
}






