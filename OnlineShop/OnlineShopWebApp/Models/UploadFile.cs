using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class UploadFile
    {
        public IFormFile File { get; set; }
        public string FileName { get { return Guid.NewGuid() + "." + File.FileName.Split('.').Last(); } }
        public string DirectoryPath { get; set; }
        public string RootPath { get; set; }
        public string FullDirectoryPath { get { return Path.Combine(RootPath + "/images/products/"); } }

        public string FilePath { get { return DirectoryPath + FileName; } }
        public UploadFile(IFormFile file, string rootPath, string DirectoryPath)
        {
            this.File = file;
            this.RootPath = rootPath;
            this.DirectoryPath = DirectoryPath;
        }
        public void SaveFile()
        {
            if (!Directory.Exists(FullDirectoryPath))
            {
                Directory.CreateDirectory(FullDirectoryPath);
            }

            using (var fileStream = new FileStream(FullDirectoryPath + FileName, FileMode.Create))
            {
                File.CopyTo(fileStream);
            }
             
        }

    }
}
