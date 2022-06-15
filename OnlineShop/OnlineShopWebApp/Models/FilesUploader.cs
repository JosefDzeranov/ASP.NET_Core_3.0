using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Models

{
    public class FilesUploader : IFilesUploader
    {
        private readonly IWebHostEnvironment appEnviroment;
        public FilesUploader(IWebHostEnvironment appEnviroment)
        {
            this.appEnviroment = appEnviroment;
        }

        public string SaveFile( IFormFile file, string folder )
        {
            if (file != null)
            {
                var directoryPath = Path.Combine(appEnviroment.WebRootPath + folder);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                var path = Path.Combine(directoryPath, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return folder + fileName;
            }

             return null;
        }

        public List<string> SaveFiles(List<IFormFile> files, string folder)
        {
            if(files != null)
            {
                var paths = new List<string>();

                foreach (var file in files)
                {
                    paths.Add(SaveFile(file, folder));
                }

                return paths;
            }
            return null;
        }

       

    }
}
