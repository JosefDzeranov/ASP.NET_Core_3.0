using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class AdminPanelRepository : IAdminPanelRepository
    {
        private List<AdmPanel> adminPanel = new List<AdmPanel>();

        public AdmPanel TryGetByUserId(string userId)
        {
            return adminPanel.FirstOrDefault(x => x.UserId == userId);
        }

        public void Changes(Product product, string userId)
        {
            var admPanel = TryGetByUserId(userId);
            adminPanel.Remove(admPanel);
            adminPanel.Add(admPanel);
        }

        public void Clear(Product product, string userId)
        {
            var existingProduct = TryGetByUserId(userId);
            adminPanel.Remove(existingProduct);
        }
    }
}
