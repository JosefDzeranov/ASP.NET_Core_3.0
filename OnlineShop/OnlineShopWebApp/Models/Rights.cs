using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Rights
    {
        public bool BeAdmin { get; set; }
        public bool BeBuyer { get; set; }

        public List<Route> tabooAdmin { get; } = new List<Route>();

        public List<Route> tabooBuyer { get; } = new List<Route>()
        {
            new Route() {Area = "Admin"}
        };

    }
}
