using FileHubBackendV2.Services;
using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FileHubBackendV2.Controllers
{
    [Route("api/fileRecords")]

    public class FileRecordsController : Controller
    {
        private readonly IFileRecordsService _fileRecordsService;

        public FileRecordsController(IFileRecordsService fileRecordsService)
        {
            _fileRecordsService = fileRecordsService;
        }

        [HttpGet] // adding non-needed anotation, but swashbuckle 3 needs it: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml, 
        public IActionResult GetFileRecords()
        {
            var fileRecords = _fileRecordsService.GetFileRecords();

            return Ok(fileRecords);
        }

        [HttpGet("{id}")]
        public IActionResult GetFileRecord(Guid id)
        {
            // PRE-CONDITION
            if (string.IsNullOrEmpty(id.ToString())) return BadRequest("file id is required");

            // ACTIONS
            FileRecord fileRecord = _fileRecordsService.GetFileRecordById(id);

            if (fileRecord == null) return NotFound();

            return Ok(fileRecord);
        }


        [EnableCors("AllowAll")]
        [HttpPost()]
        public IActionResult CreateFileRecord(FileRecord fileRecord)
        {
            // PRE-CONDITION
            if (fileRecord == null) return BadRequest("fileRecord is required");
            if (string.IsNullOrEmpty(fileRecord.Name)) return BadRequest("file record name is required");

            // ACTIONS
            var fileRecordCreated = _fileRecordsService.CreateFileRecord(fileRecord);
            return Ok(fileRecordCreated);
        }
    }
}