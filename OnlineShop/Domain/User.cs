using Microsoft.AspNetCore.Identity;

namespace Domains
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string login)
        {
            Login = login;
        }
        public User() { }


    }
}
