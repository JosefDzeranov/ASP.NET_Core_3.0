using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class User
    {
        public Cart Cart = new Cart();

        public static int IdCounter = 0;

        public int Id { get; }

        public User()
        {
            IdCounter++;
            Id = IdCounter; 
        }
    }
}
