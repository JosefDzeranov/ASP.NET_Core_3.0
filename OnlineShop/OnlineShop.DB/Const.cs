using System;

namespace OnlineShop.DB
{
    public static class Const
    {
        public static Guid UserId;
        public static string AdminRole = "Admin";
        public static string UserRole = "User";
        static Const()
        {
            UserId = Guid.NewGuid();
        }
    }

   
}
