﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime OrderDateTime { get; set; }

        public string UserId { get; set; }

        public List<Customer> Customer { get; set; }

        public List<OrderItem> Items { get; set; }

        /// <summary>
        //// Общее кол-во наименований товара
        /// </summary>
        public int CountItems
        {
            get
            {
                return Items.Sum(x => x.Count);
            }
        }

        public decimal CostOrder
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }

        //public Order(string userId, string lastName, string name, string phone, string mail, string address)
        //{
        //    UserId = userId;

        //    Id = Guid.NewGuid();

        //    OrderNumber++;

        //    OrderDateTime = DateTime.Now;

        //    LastName = lastName;

        //    Name = name;

        //    Phone = phone;

        //    Mail = mail;

        //    Address = address;
        //}
    }
}