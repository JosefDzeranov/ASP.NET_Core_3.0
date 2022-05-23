using System;

namespace OnlineShopWebApp
{
    public static class Const
    {
        public static Guid UserId;
        static Const()
        {
            UserId = Guid.NewGuid();
        }
    }

   
}
