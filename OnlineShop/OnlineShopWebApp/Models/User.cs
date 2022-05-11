using System;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { } // Empty ctor for XML serializing.

        public User(Guid id, string firstname, string lastname, string role, string phone, string email, string password)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }
}
