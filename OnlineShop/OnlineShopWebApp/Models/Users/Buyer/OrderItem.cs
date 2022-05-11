using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderItem
    {
        public List<CartItem> CartItem { get; set; }
        public InfoBuying InfoBuying { get; set; }
        public DateTime dateTime { get; set; }
        public string Status { get; set; }
        public string Login { get; set; }
        public decimal FullCost { get; set; }

        public List<string> RosterStatus { get; } = new List<string>()
        {
            "Создан",
            "Обработан",
            "В пути",
            "Отменён",
            "Доставлен"
        };

        public OrderItem(List<CartItem> cartItem, string login, InfoBuying infoBuying)
        {
            CartItem = new List<CartItem>(cartItem);
            CalculateFullCostOrder();
            dateTime = DateTime.UtcNow;
            Status = RosterStatus[0];
            Login = login;
            InfoBuying = infoBuying;
        }

        public string DataRegistration()
        {
            string data = string.Format("{0:00}.{1:00}.{2:0000}", dateTime.Day, dateTime.Month, dateTime.Year);
            return data;
        }
        public string TimeRegistration()
        { //По Гринвичу
            string data = string.Format("{0:00}:{1:00}:{2:00}", dateTime.Hour, dateTime.Minute, dateTime.Second);
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
