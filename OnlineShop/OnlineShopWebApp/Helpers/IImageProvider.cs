using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public interface IImageProvider
    {
        List<string> SaveFiles(IFormFile[] files, ImageFolders folder);
        string SaveFile(IFormFile file, ImageFolders folder);
    }
}
