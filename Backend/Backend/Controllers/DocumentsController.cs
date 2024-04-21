using Backend.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{

    public class DocumentsController : AppControllerBase
    {
        private readonly IAzureObjectStoreService _objectStore;

        public DocumentsController(IAzureObjectStoreService objectStore,ILogger<DocumentsController> logger) : base(logger)
        {
            _objectStore = objectStore;
        }


        // GET: api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Get(IFormFile file)
        {
            await _objectStore.Create(file.OpenReadStream(),file.FileName, null);
            return Ok();
        }
    }
}
