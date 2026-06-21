using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileUploadservice
{
    public class FileUploadservice : IFileUploadservice
    {
        private readonly string _storagepath;
        public FileUploadservice(IConfiguration configuration)
        {

            _storagepath = configuration["FileUpload:StoragePath"]
                 ?? throw new ArgumentNullException("FileUpload:StoragePath not configured");
        }




        public async Task<bool> DeleteFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Invalid file name");

            var fullPath = Path.Combine(_storagepath, fileName);

            if (!File.Exists(fullPath))

                return false;


            File.Delete(fullPath);

            return true;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (!Directory.Exists(_storagepath))
            {
                Directory.CreateDirectory(_storagepath);
            }
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or not provided");
            }
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(_storagepath, filename);

            using (var strem = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(strem);
            }

            return filename;


        }

    }
}
