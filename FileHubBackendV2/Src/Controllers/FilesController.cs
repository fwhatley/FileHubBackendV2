using FileHubBackendV2.Services;
using FileHubBackendV2.Src.Models;
using FileHubBackendV2.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Threading.Tasks;

namespace FileHubBackendV2.Controllers
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
            var files = _filesService.GetFiles();

            return Ok(files);
        }

        [HttpGet("downloadFile/{id}")]
        public IActionResult DownloadFile(Guid id)
        {
            // For file downloads use FhFile
            // https://www.codeproject.com/Articles/1203408/Upload-Download-Files-in-ASP-NET-Core
            // https://www.c-sharpcorner.com/article/sending-files-from-web-api/
            // PRE-CONDITION
            if (string.IsNullOrEmpty(id.ToString())) return BadRequest("file id is required");

            // ACTIONS
            FileDownloadDto fileDownloadDto = _filesService.GetFileDownloadStreamById(id);
            
            if (fileDownloadDto == null) return NotFound();

            var contentType = FileHelpers.GetContentType(fileDownloadDto.FileName);
            var fileName = fileDownloadDto.FileName;
            var contentStream = fileDownloadDto.DownloadContentStream;

            return File(contentStream, contentType, fileName);
        }

        [HttpGet("{id}")]
        public IActionResult GetFile(Guid id)
        {
            // PRE-CONDITION
            if (string.IsNullOrEmpty(id.ToString())) return BadRequest("file id is required");

            // ACTIONS
            FhFile fhFileToReturn = _filesService.GetFile(id);

            if (fhFileToReturn == null) return NotFound();

            return Ok(fhFileToReturn);
        }

        [EnableCors("AllowAll")]
        [AddSwaggerFileUploadButton]
        [HttpPost()]
        // aka upload file
        public async Task<IActionResult> CreateFile(IFormFile formFile, Guid fileRecordId, string fileName)
        {
            // PRE-CONDITION
            if (formFile == null) return BadRequest("file is required");
            if (formFile.Length <= 0) return BadRequest("file is required");
            if (string.IsNullOrEmpty(fileRecordId.ToString())) return BadRequest("fileRecordId is required");
            if (string.IsNullOrEmpty(fileName)) return BadRequest("filename is required");

            var file = new FhFile
            {
                FileName = fileName,
                FileRecordId = fileRecordId
            };

            // ACTIONS
            var fileDto = await _filesService.CreateFile(formFile, file);
            return Ok(fileDto);
        }
    }
}