using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Cоздан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "В пути")]
        OnTheWay,

        [Display(Name = "Отменен")]
        Canceled,

        [Display(Name = "Доставлен")]
        Delivered

    }
}