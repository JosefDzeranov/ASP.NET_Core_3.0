using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace OnlineShopWebApp.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;

        public ImagesProvider(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        public string GetFolderPath(string folderName)
        {
            string folderImagePath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folderName);
            if (!Directory.Exists(folderImagePath))
            {
                Directory.CreateDirectory(folderImagePath);
            }
            return folderImagePath;
        }
    }
}

