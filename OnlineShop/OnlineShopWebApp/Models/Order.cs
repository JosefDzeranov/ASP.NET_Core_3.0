using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order 
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }
        

        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

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
    }
}