using FileHubBackendV2.Models;
using FileHubBackendV2.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileHubBackendV2.Services
{
    public class FilesService: IFilesService
    {
        private readonly IFilesRepository _filesRepository;
        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public FileFeDto GetFileById(string id)
        {
            return _filesRepository.GetFileById(id);
        }

        public IEnumerable<FileFeDto> GetAllFiles()
        {
            return _filesRepository.GetAllFiles();
        }

        public async Task<FileFeDto> UploadFile(IFormFile file)
        {
            return await _filesRepository.UploadFile(file);
        }

        public FileDownloadDto GetFileDownloadStreamById(string id)
        {
            return _filesRepository.GetFileDownloadStreamById(id);
        }
    }
}
