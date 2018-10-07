using FileHubBackendV2.Services;
using FileHubBackendV2.Src.Models;
using FileHubBackendV2.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Threading.Tasks;

namespace FileHubBackendV2.Src.Controllers
{
    [Route("api/files")]

    public class FilesController : Controller
    {
        private readonly IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpGet] // adding non-needed anotation, but swashbuckle 3 needs it: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml, 
        public IActionResult GetFiles()
        {
            var files = _filesService.GetAllFiles();
            return Ok(files);
        }

        [HttpGet("downloadFile/{id}")]
        public IActionResult DownloadFile(Guid id)
        {
            // For file downloads use File
            // https://www.codeproject.com/Articles/1203408/Upload-Download-Files-in-ASP-NET-Core
            // https://www.c-sharpcorner.com/article/sending-files-from-web-api/
            // PRE-CONDITION
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("file id is required for download");
            }

            // ACTIONS
            FileDownloadDto fileDownloadDto = _filesService.GetFileDownloadStreamById(id);
            
            if (fileDownloadDto == null)
            {
                return NotFound();
            }

            var contentType = FileHelpers.GetContentType(fileDownloadDto.FileName);
            var fileName = fileDownloadDto.FileName;
            var contentStream = fileDownloadDto.DownloadContentStream;

            return File(contentStream, contentType, fileName);
        }

        [HttpGet("{id}")]
        public IActionResult GetFile(Guid id)
        {
            // PRE-CONDITION
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("file id is required");
            }

            // ACTIONS
            FileRecord fileToReturn = _filesService.GetFileById(id);
            
            if (fileToReturn == null)
            {
                return NotFound();
            }

            return Ok(fileToReturn);
        }

        [AddSwaggerFileUploadButton]
        [HttpPost()]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileDto = await _filesService.UploadFile(file);
            return Ok(fileDto);
        }
    }
}