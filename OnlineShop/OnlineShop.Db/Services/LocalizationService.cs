using OnlineShop.Db.Models;
using System.Linq;

namespace OnlineShop.Db.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly DatabaseContext _databaseContext;

        public LocalizationService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ProductResource GetProductResource(string resourceKey, int languageId)
        {
            return _databaseContext.ProductResources.FirstOrDefault(r => r.Name == resourceKey && r.LanguageId == languageId);
        }

    }
}
