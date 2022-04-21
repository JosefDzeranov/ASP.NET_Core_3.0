using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public int Id { get; }
        public string FistName { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Email { get; }
        private string password;
        public User(int id, string fistName, string surname, int age, string email, string password_input)
        {
            Id = id;
            FistName = fistName;
            Surname = surname;
            Age = age;
            Email = email;
            password = password_input;
        }
    }
}
