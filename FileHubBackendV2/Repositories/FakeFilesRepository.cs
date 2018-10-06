using FileHubBackendV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHubBackendV2.Repositories
{
    public class FakeFilesRepository : IFilesRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private List<FileFeDto> FilesList;

        public FakeFilesRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            FilesList = new List<FileFeDto>()
            {
                new FileFeDto()
                {
                    Id = "1",
                    Description = "Description 1",
                    Name = "name 1",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto()
                {
                    Id = "2",
                    Description = "Description 2",
                    Name = "name 2",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue

                },
                new FileFeDto()
                {
                    Id = "3",
                    Description = "Description 3",
                    Name = "name 3",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto()
                {
                    Id = "4",
                    Description = "Description 4",
                    Name = "name 4",
                    Url = "https://via.placeholder.com/350x150",
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto()
                {
                    Id = "5",
                    Description = "Description 5",
                    Name = "name 5",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                }
            };
        }

        public async Task<FileDownloadDto> GetFileById(string id)
        {
            var file = FilesList.FirstOrDefault(f => f.Id == id);

            // map file contents
            FileDownloadDto fileDownload = new FileDownloadDto();

            return fileDownload;
        }

        FileFeDto IFilesRepository.GetFileById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileFeDto> GetAllFiles()
        {
            return FilesList;
        }

        public async Task<FileFeDto> UploadFile(IFormFile file)
        {

            var fileDto = new FileFeDto()
            {
                CreatedUtc = DateTime.UtcNow,
                DeletedUtc = DateTime.MaxValue,
                Description = "This is file description",
                Id = Guid.NewGuid().ToString(),
                Name = file.FileName
            };

            FilesList.Add(fileDto);

            return fileDto;

        }

        public FileDownloadDto GetFileDownloadStreamById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
