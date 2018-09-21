using FileHubBackendV2.DataStore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FileHubBackendV2.Controllers
{
    [Route("api/files")]

    public class FilesController : Controller
    {
        [HttpGet] // adding non-needed anotation for swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml, 
        public IActionResult GetFiles()
        {
            return Ok(FilesDataStore.Current.Files);
        }

        [HttpGet("{id}")]
        public IActionResult GetFile(int id)
        {
            var fileToReturn = FilesDataStore.Current.Files.FirstOrDefault(f => f.Id == id);
            if (fileToReturn == null)
            {
                return NotFound();
            }

            return Ok(fileToReturn);
        }
    }
}