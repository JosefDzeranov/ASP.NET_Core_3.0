using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFilesUploader
    {
        string SaveFile(IFormFile file, string folder);
        List<string> SaveFiles(List<IFormFile> files, string folder);

    }
}
