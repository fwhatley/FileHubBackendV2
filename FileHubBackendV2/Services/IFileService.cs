using FileHubBackendV2.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileHubBackendV2.Services
{
    public interface IFilesService
    {
        FileFeDto GetFileById(string id);
        IEnumerable<FileFeDto> GetAllFiles();
        Task<FileFeDto> UploadFile(IFormFile file);
        FileDownloadDto GetFileDownloadStreamById(string id);
    }
}
