using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public enum OrderStatus_ViewModel
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обрабатывается")]
        Processed,

        [Display(Name = "Доставка")]
        Delivering,

        [Display(Name = "Доставлено")]
        Delivered,

        [Display(Name = "Закрыт")]
        Canceled
    }
}
