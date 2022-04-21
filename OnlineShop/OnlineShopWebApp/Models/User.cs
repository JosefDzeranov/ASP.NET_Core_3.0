using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public int Id { get; }
        public string Fistname { get; }
        public string Secondname { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Email { get; }
        private string password;
        public User(int id, string fistname, string secondname, string surname, int age, string email, string password_input)
        {
            Id = id;
            Fistname = fistname;
            Secondname = secondname;
            Surname = surname;
            Age = age;
            Email = email;
            password = password_input;
        }
    }
}
