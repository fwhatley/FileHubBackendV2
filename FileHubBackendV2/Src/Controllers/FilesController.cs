using FileHubBackendV2.Services;
using FileHubBackendV2.Src.Models;
using FileHubBackendV2.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileHubBackendV2.Controllers
{

    /// <summary>
    /// Controller's job
    ///     - validate data
    ///         - return right away if data is invalid. eg., return badRequest if filename is required and not provided
    ///     - initilize required data. eg., initilize DeleteUtc to date.maxValue
    /// </summary>
    [Route("api/files")]

    public class FilesController : Controller
    {
        private readonly IFilesService _filesService;
        private IFileRecordsService _fileRecordsService;

        public FilesController(IFilesService filesService, IFileRecordsService fileRecordsService)
        {
            _filesService = filesService;
            _fileRecordsService = fileRecordsService;
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
        public async Task<IActionResult> CreateFile(IFormFile file, Guid fileRecordId, string fileName)
        {
            // PRE-CONDITION
            if (file == null) return BadRequest("file is required");
            if (file.Length <= 0) return BadRequest("file is required");
            if (string.IsNullOrEmpty(fileName)) return BadRequest("fileName is required");
            
            // verify provided fileRecordId is not associated with a file
            if (fileRecordId != Guid.Empty)
            {
                var files = _filesService.GetFiles().ToList();
                var foundFileRecordId = files.FirstOrDefault(f => f.FileRecordId == fileRecordId);
                if (foundFileRecordId != null)
                {
                    return BadRequest($"Invalid fileRecordId: {fileRecordId}. FileRecordId is already associated with a file.");
                }
            }


            var fhFile = new FhFile
            {
                Name = fileName,
                FileRecordId = fileRecordId,
                CreatedUtc = DateTime.Now, // add required data
                UpdatedUtc = DateTime.Now,
                DeletedUtc = DateTime.MaxValue
            };

            // initialize required data

            // ACTIONS
            var fileDto = await _filesService.CreateFile(file, fhFile);
            return Ok(fileDto);
        }
    }
}