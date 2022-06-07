
namespace OnlineShopWebApp.Models
{
    public enum OrderState
    {
        /// <summary>
        /// Создан
        /// </summary>
        Created,

        /// <summary>
        /// Обработан
        /// </summary>
        Finish,

        /// <summary>
        /// В пути
        /// </summary>
        Delivering,

        /// <summary>
        /// Доставлен
        /// </summary>
        Delivered,

        /// <summary>
        /// Отменён
        /// </summary>
        Canceled
    }
}