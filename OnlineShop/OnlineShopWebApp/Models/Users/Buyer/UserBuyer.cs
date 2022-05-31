using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;


namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class UserBuyer
    {
        public string Login { get; set; }
        public List<ProductViewModel> Comparisons { get; set; } = new List<ProductViewModel>();
        public List<CartItem> Cart { get; set; } = new List<CartItem>();
        public InfoBuying InfoBuying { get; set; } = new InfoBuying();
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

        public decimal SumCost(List<CartItem> listProducts)
        {
            decimal sum = 0;
            foreach (var product in listProducts)
            {
                sum += product.Product.Cost * product.Count;
            }
            return sum;
        }

        public int SumAllProducts()
        {
            int sum = 0;
            foreach (var prod in Cart)
            {
                for (int i = 0; i < prod.Count; i++)
                {
                    sum++;
                }
            }
            return sum;
        }

    }
}
