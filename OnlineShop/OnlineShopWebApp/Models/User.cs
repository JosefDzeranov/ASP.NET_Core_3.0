namespace OnlineShopWebApp.Models
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
