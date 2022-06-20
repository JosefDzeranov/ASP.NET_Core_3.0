using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IImagesProvider
    {
        string SafeFile(IFormFile file, ImageFolders folder);
        List<string> SafeFiles(IFormFile[] files, ImageFolders folder);
    }
}