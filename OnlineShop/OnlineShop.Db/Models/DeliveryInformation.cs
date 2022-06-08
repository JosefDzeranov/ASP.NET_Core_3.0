using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class DeliveryInformation
    {    
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public string Adress { get; set; }       
        public string Phone { get; set; }        
        public string Email { get; set; }
    }
}
