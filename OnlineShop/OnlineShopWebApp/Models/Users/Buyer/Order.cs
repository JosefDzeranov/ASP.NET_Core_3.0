using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderStatus Status { get; set; }
        public string LoginBuyer { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.UtcNow;
        }

        public string ShowUnitRegisterStatus(int index)
        {
            return MyConstant.RosterStatus[index];
        }

        public string DataRegistration()
        {
            string data = string.Format("{0:00}.{1:00}.{2:0000}", CreateDateTime.Day, CreateDateTime.Month, CreateDateTime.Year);
            return data;
        }
        public string TimeRegistration()
        { //По Гринвичу
            string data = string.Format("{0:00}:{1:00}:{2:00}", CreateDateTime.Hour, CreateDateTime.Minute, CreateDateTime.Second);
            return data;
        }
        public decimal FullCost()
        {
            decimal fullCost = 0;
            foreach (var cartItem in Items)
            {
                foreach (var v in cartItem.additionalOptions)
                {
                    fullCost += (v.TotalCost() + cartItem.Product.Cost);
                }
            }
            return fullCost;
        }

    }
}
