using System;
using System.Collections.Generic;
using OnlineShopWebApp.Interfase;


namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class UserBuyer : User
    {
        public List<Product> Comparisons { get; set; } = new List<Product>();
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

        public void AddProductInCart(Product product)
        {
            var existingCartItem = Cart.Find(x => x.Product.Id == product.Id);
            if (existingCartItem != null)
            {
                existingCartItem.UpCount();
            }
            else
            {
                Cart.Add(new CartItem(product));
            }
        }

        public void DeleteProductInCart(Guid productId)
        {
            Cart.RemoveAll(cartItem => cartItem.Product.Id == productId);
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

        public void ReduceDuplicateProductCart(Guid productId)
        {
            var existingCartItem = Cart.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.DownCount();
            }

            if (existingCartItem.Count <= 0)
            {
                Cart.Remove(existingCartItem);
            }

        }

        public void ClearCart()
        {
            Cart.Clear();
        }

        public void Buy()
        {
            Orders.Add(new OrderItem(Cart, Login, InfoBuying));
            Cart.Clear();
        }

        public void SaveInfoBuying(InfoBuying infoBuying)
        {
            this.InfoBuying = infoBuying;
        }

        public UserBuyer(IRoleManager roleManager) : base(roleManager)
        {
        }
    }
}
