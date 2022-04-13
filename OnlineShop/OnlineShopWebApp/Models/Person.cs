using System;

namespace OnlineShopWebApp.Models
{
    public class Person
    {
        public int Id { get; }
        public string FistName { get;}
        public string Surname { get;}
        public int Age { get;}
        public string Email { get;}

        private string password;
        public Person(int id, string fistName, string surname, int age, string email, string password_input)
        {
            Id = id;
            FistName = fistName;
            Surname = surname;
            Age = age;
            Email = email;
            password = password_input;
        }
        public override string ToString()
        {
            return $"Id: {Id};\nИмя: {FistName};\nФамилия: {Surname};\nВозраст: {Age};\nEmail: {Email};";
        }
    }
}
