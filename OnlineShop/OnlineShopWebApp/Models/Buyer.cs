﻿using System.Collections.Generic;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Models
{
    public class Buyer: User
    {

        public List<Product> Comparisons { get; set; } = new List<Product>();
        public List<CartItem> Cart { get; set; } = new List<CartItem>();
        public List<CartItem> Orders { get; set; } = new List<CartItem>();

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

        public void ReduceDuplicateProductCart(int productId)
        {
            var existingCartItem = Cart.Find(x => x.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Count--;
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

        public void ReportTransaction()
        {
            Orders.AddRange(Cart);
            Cart.Clear();
        }
    }
}
