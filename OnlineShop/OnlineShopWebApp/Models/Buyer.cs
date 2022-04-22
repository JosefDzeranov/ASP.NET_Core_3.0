using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;


namespace OnlineShopWebApp.Models
{
    public class Buyer: User
    {
        public class CartBuyer
        {
            public Product Product { get; set; }
            public int NumDuplicates { get; set; }
        }
        public List<Product> ComparisonList { get; set; }
        public List<CartBuyer> CartList { get; set; }
        public List<CartBuyer> OrdersList { get; set; }
        public Buyer(int id, string fistname, string secondname, string surname, int age, string email, string password_input) 
            : base(id, fistname, secondname, surname, age,  email,  password_input)
        {
            ComparisonList = new List<Product>();
            CartList = new List<CartBuyer>();
            OrdersList = new List<CartBuyer>();
        }
        public override string ToString()
        {
            return $"Id: {Id};\nИмя: {Fistname};\nФамилия: {Surname};\nВозраст: {Age};\nEmail: {Email};";
        }
        public decimal SumCost(List<CartBuyer> listProducts)
        {
            decimal sum = 0;
            foreach (var product in listProducts)
            {
                sum += product.Product.Cost * product.NumDuplicates;
            }
            return sum;
        }
        public List<CartBuyer> SumDuplicates(Product product)
        {
            if (CartList.Find(x => x.Product.Id == product.Id)!=null)
            {
                for (int i = 0; i < CartList.Count; i++)
                {
                    if (product.Id == CartList[i].Product.Id)
                    {
                        CartList[i].NumDuplicates++;
                    }
                }
            }
            else
            {
                CartList.Add(new CartBuyer(){Product = product, NumDuplicates = 1});
            }
            return CartList;
        }
    }
}
