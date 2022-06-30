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

        public ProductNameResource GetProductNames(string resourceKey, int languageId)
        {
            return _databaseContext.Names.FirstOrDefault(r => r.Name == resourceKey && r.LanguageId == languageId);
        }
        
        public ProductDescResource GetProductDescriptions(string resourceKey, int languageId)
        {
            return _databaseContext.Descriptions.FirstOrDefault(r => r.Name == resourceKey && r.LanguageId == languageId);
        }

    }
}
