using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class DeliveryInfo
    {
        [Required(ErrorMessage = "Введите адрес доставки")]
        public string AdressToDelivery { get; set; }
        [Required(ErrorMessage = "Укажите контактное лицо")]
        public string NameOfClient { get; set; }
        [Required(ErrorMessage = "Укажите контактный телефон")]
        public string Phone { get; set; }
    }
}
