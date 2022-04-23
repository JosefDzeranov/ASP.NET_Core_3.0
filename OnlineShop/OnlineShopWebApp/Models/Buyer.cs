using System.Collections.Generic;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Models
{
    public class Buyer: User
    {

        public List<Product> Comparison { get; set; }
        public List<CartItem> Cart { get; set; }
        public List<CartItem> Orders { get; set; }
        public Buyer(int id, string fistname, string secondname, string surname, int age, string email, string password_input) 
            : base(id, fistname, secondname, surname, age,  email,  password_input)
        {
            Comparison = new List<Product>();
            Cart = new List<CartItem>();
            Orders = new List<CartItem>();
        }
        public override string ToString()
        {
            return $"Id: {Id};\nИмя: {Fistname};\nФамилия: {Surname};\nВозраст: {Age};\nEmail: {Email};";
        }
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
                existingCartItem.Count++;
            }
            else
            {
                Cart.Add(new CartItem(){Product = product, Count = 1});
            }
        }

        public void DeleteProductInCart(int productId)
        {
            Cart.RemoveAll(CartItem => CartItem.Product.Id == productId);
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

        public void ReduceDuplicateProductCart(int productId)
        {
            var existingCartItem = Cart.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Count--;
            }

            if (existingCartItem.Count <= 0)
            {
                Cart.RemoveAll(CartItem.)
            }
            else
            {
                Cart.Add(new CartItem() { Product = product, Count = 1 });
            }
        }
    }
}
