using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public class ImageProvider : IImageProvider
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageProvider(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public List<string> SaveFiles(IFormFile[] files, ImageFolders folder)
        {
            if (files != null)
            {
                var imagePaths = new List<string>();
                foreach (var file in files)
                {
                    var imagePath = SaveFile(file, folder);
                    imagePaths.Add(imagePath);
                }
                return imagePaths;
            }
            return null;
        }

        public string SaveFile(IFormFile file, ImageFolders folder)
        {
            if (file != null)
            {
                var folderPath = Path.Combine(_appEnvironment.WebRootPath + "/img/" + folder);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split(".").Last();
                string path = Path.Combine(folderPath, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return "/img/" + folder + "/" + fileName;
            }
            return null;
        }
    }
}
