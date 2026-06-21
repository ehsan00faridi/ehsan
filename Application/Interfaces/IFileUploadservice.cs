using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFileUploadservice
    {
        Task<string> UploadFileAsync(IFormFile file);

        Task<bool> DeleteFile(string fileName);
    }
}
