using System.Collections.Generic;

namespace OnlineShopWebApp.Interfase
{
    public interface IWorkWithData
    {
        public string WriteToStorage<T>(List<T> TlistObjects);

        public List<T> ReadToStorage<T>();
    }
}
