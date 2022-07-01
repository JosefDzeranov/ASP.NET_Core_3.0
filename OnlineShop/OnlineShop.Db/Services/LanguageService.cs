using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly DatabaseContext _databaseContext;

        public LanguageService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Language> GetLanguages()
        {
            return _databaseContext.Languages.ToList();
        }

        public Language GetLangugeByCulture(string culture)
        {
            return _databaseContext.Languages.FirstOrDefault(lang => lang.Culture == culture);
        }
    }
}
