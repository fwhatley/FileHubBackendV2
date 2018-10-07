using FileHubBackendV2.Src.Models;
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

        private List<FileRecord> FilesList;

        public FakeFilesRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            FilesList = new List<FileRecord>()
            {
                new FileRecord()
                {
                    Id = new Guid(),
                    Description = "Description 1",
                    Name = "name 1",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord()
                {
                    Id = new Guid(),
                    Description = "Description 2",
                    Name = "name 2",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue

                },
                new FileRecord()
                {
                    Id = new Guid(),
                    Description = "Description 3",
                    Name = "name 3",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord()
                {
                    Id = new Guid(),
                    Description = "Description 4",
                    Name = "name 4",
                    Url = "https://via.placeholder.com/350x150",
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord()
                {
                    Id = new Guid(),
                    Description = "Description 5",
                    Name = "name 5",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                }
            };
        }

        public FileDownloadDto GetFileDownloadStreamById(Guid id)
        {
            var file = FilesList.FirstOrDefault(f => f.Id == id);

            // map file contents
            FileDownloadDto fileDownload = new FileDownloadDto();

            return fileDownload;
        }

        public FileRecord GetFileById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileRecord> GetAllFiles()
        {
            return FilesList;
        }

        public FileRecord UploadFile(IFormFile file)
        {

            var fileDto = new FileRecord()
            {
                CreatedUtc = DateTime.UtcNow,
                DeletedUtc = DateTime.MaxValue,
                Description = "This is file description",
                Id = Guid.NewGuid(),
                Name = file.FileName
            };

            FilesList.Add(fileDto);

            return fileDto;

        }

        Task<FileRecord> IFilesRepository.UploadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
