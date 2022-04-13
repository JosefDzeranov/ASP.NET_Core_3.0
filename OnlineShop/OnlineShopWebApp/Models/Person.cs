using System;

namespace OnlineShopWebApp.Models
{
    public class Person
    {
        public int Id { get; }
        public string FistName { get;}
        public string SecondName { get;}
        public string DateOfBirth { get;}
        public string Email { get;}

        private string password;
        public Person(int id, string fistName, string secondName, string dateOfBirth, string email, string password_input)
        {
            Id = id;
            FistName = fistName;
            SecondName = secondName;
            DateOfBirth = dateOfBirth;
            Email = email;
            password = password_input;
        }
        public override string ToString()
        {
            return $"Id={Id}\nFistName={FistName}\nSecondName={SecondName}\nDateOfBirth={DateOfBirth}\nEmail={Email}\npassword={password}";
        }
    }
}
