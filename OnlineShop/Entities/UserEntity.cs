using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class UserEntity : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserEntity(string login)
        {
            Login = login;
        }
        public UserEntity() { }


    }
}
