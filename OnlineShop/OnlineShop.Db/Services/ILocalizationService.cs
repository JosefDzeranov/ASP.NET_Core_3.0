using OnlineShop.Db.Models;

namespace OnlineShop.Db.Services
{
    public interface ILocalizationService
    {
        ProductResource GetProductResource(string resourceKey, int languageId);
    }
}
