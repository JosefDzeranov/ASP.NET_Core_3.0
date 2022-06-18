using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;

        public ImagesProvider(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        public List<string> SaveFiles(List<IFormFile> files, ImagesFolders folder)
        {
            var imagesPaths = new List<string>();
            foreach (var file in files)
            {
                var imagePath = SaveFile(file, folder);
                imagesPaths.Add(imagePath);
            }
            return imagesPaths;
        }

        public string SaveFile(IFormFile file, ImagesFolders folder)
        {
            if (file != null)
            {
                string folderImagePath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folder);
                if (!Directory.Exists(folderImagePath))
                {
                    Directory.CreateDirectory(folderImagePath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                string path = Path.Combine(folderImagePath, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return "/images/" + folder + "/" + fileName;
            }
            return null;
        }

        public void Delete(string imagePath)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(appEnvironment.WebRootPath + imagePath));
            fileInfo.Delete();
        }
    }
}
