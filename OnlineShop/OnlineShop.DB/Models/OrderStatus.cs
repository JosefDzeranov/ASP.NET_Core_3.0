using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DB.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Новый")]
        New,
        [Display(Name = "Подтвержден")]
        Confirmed,
        [Display(Name = "Оплачен")]
        Paid,
        [Display(Name = "Доставлен")]
        Delivered

    }
}
