using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class AdmPanel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
        public AdmPanel() { }
        public AdmPanel(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Products = new List<Product>();
        }
    }
}
