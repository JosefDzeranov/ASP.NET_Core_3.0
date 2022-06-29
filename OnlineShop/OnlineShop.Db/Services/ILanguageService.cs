using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db.Services
{
    public interface ILanguageService
    {
        List<Language> GetLanguages();
        Language GetLangugeByCulture(string culture); 
    }
}
