using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : AppControllerBase
    {
        public FileController(ILogger<FileController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            string[] filesNames = new string[files.Count];

            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Length > 0)
                {
                    var fileParts = files[i].FileName.Split(".");
                    var fileName = Guid.NewGuid().ToString() +"." + fileParts[fileParts.Length - 1];
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

                    filesNames[i] = fileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await files[i].CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(filesNames);
        }
    }
}
