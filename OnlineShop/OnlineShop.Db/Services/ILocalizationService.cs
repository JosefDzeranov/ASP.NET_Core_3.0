using OnlineShop.Db.Models;

namespace OnlineShop.Db.Services
{
    public interface ILocalizationService
    {
        ProductNameResource GetProductNames(string resourceKey, int languageId);
        ProductDescResource GetProductDescriptions(string resourceKey, int languageId);
    }
}
