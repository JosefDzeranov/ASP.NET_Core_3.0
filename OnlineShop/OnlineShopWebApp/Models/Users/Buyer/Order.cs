using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartItem> CartItem { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public string Login { get; set; }
        public decimal FullCost { get; set; }

        public Order()
        {

        }

        public Order(List<CartItem> cartItem, string login, UserDeleveryInfo userDeleveryInfo)
        {
            Id = Guid.NewGuid();
            CartItem = new List<CartItem>(cartItem);
            CalculateFullCostOrder();
            DateTime = DateTime.UtcNow;
            Status = MyConstant.RosterStatus[0];
            Login = login;
            UserDeleveryInfo = userDeleveryInfo;
        }

        public string ShowUnitRegisterStatus(int index)
        {
            return MyConstant.RosterStatus[index];
        }

        public string DataRegistration()
        {
            string data = string.Format("{0:00}.{1:00}.{2:0000}", DateTime.Day, DateTime.Month, DateTime.Year);
            return data;
        }
        public string TimeRegistration()
        { //По Гринвичу
            string data = string.Format("{0:00}:{1:00}:{2:00}", DateTime.Hour, DateTime.Minute, DateTime.Second);
            return data;
        }
        public void CalculateFullCostOrder()
        {
            FullCost = 0;
            foreach (var cartItem in CartItem)
            {
                foreach (var v in cartItem.additionalOptions)
                {
                    FullCost += (v.TotalCost() + cartItem.Product.Cost);
                }
            }

        }

    }
}
