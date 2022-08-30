using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class DeliveryInfoModelView

    {
        [Required(ErrorMessage = "Введите адрес доставки")]
        public string AdressToDelivery { get; set; }
        [Required(ErrorMessage = "Укажите контактное лицо")]
        public string NameOfClient { get; set; }
        [Required(ErrorMessage = "Укажите контактный телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Укажите Email")]
        public string Email { get; set; }

    }
}
