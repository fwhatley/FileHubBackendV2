using FileHubBackendV2.Repositories;
using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Http;
using System;
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

        public FhFile GetFile(Guid id)
        {
            return _filesRepository.GetFile(id);
        }

        public IEnumerable<FhFile> GetFiles()
        {
            return _filesRepository.GetFiles();
        }

        public async Task<FhFile> CreateFile(IFormFile formFile, FhFile file)
        {
            return await _filesRepository.CreateFile(formFile, file);
        }

        public FileDownloadDto GetFileDownloadStreamById(Guid id)
        {
            return _filesRepository.GetFileDownloadStreamById(id);
        }
    }
}
