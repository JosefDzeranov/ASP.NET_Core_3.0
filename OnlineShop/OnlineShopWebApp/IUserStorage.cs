using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IUserStorage
    {
        void CreateUser(SignUp signup);
        void AuthorizeUser(SignIn signin);
    }
}
