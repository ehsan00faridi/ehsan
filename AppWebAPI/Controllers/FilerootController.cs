using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class FilerootController : ControllerBase
    {
        private readonly string _storagePath;

        public FilerootController(IConfiguration configuration)
        {
            _storagePath = configuration["FileUpload:StoragePath"]
                ?? throw new ArgumentNullException("FileUpload:StoragePath not configured");
        }

        [HttpGet("GetFile")]
        public IActionResult DownloadFile([FromQuery] string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return BadRequest("Filename is required.");


            var safeFileName = Path.GetFileName(filename);
            var fullPath = Path.Combine(_storagePath, safeFileName);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found.");


            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fullPath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return PhysicalFile(fullPath, contentType, safeFileName);
        }
    }
}
