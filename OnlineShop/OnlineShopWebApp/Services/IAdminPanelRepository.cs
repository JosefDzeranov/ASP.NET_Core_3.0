using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IAdminPanelRepository
    {
        void Changes(Product product, string userId);
        void Clear(Product product, string userId);
        AdmPanel TryGetByUserId(string userId);
    }
}