using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileHubBackendV2.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public FileFeDto GetFileById(string id)
        {
            
            FileFeDto file = new FileFeDto();
            using (var db = new FileHubContext())
            {
                Console.Write("Getting by id");
                var query = from f in db.Files
                    orderby f.Name
                    where f.Id == id
                    select f;

                file = query.FirstOrDefault();
            }

            return file;
        }

        public FileDownloadDto GetFileDownloadStreamById(string id)
        {
            FileFeDto fileDto = new FileFeDto();
            using (var db = new FileHubContext())
            {
                Console.Write("Getting by id");
                var query = from f in db.Files
                    orderby f.Name
                    where f.Id == id
                    select f;

                fileDto = query.FirstOrDefault();
            }

            FileDownloadDto fileDownloadDto = new FileDownloadDto
            {
                FileName = fileDto.Name,
                DownloadContentStream = getFileDataStream(id),
                FileFullPath = getFileFullPathById(id)
                
            };

            return fileDownloadDto;
        }

        /// <summary>
        /// returns a file stream of the identified file by id
        /// reference used: https://www.c-sharpcorner.com/article/sending-files-from-web-api/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private MemoryStream getFileDataStream(string id)
        {
            var fullFilePath = getFileFullPathById(id);
            
            //converting file into bytes array  
            var dataBytes = File.ReadAllBytes(fullFilePath);
            
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);
            return dataStream;
        }

        private string getFileFullPathById(string id)
        {

            var pathToUploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, FhConstants.UploadsFolderName);
            var filePath = Path.Combine(pathToUploadFolder, id);
            return filePath;
        }

        public IEnumerable<FileFeDto> GetAllFiles()
        {
            IEnumerable<FileFeDto> files = new List<FileFeDto>();
            using (var db = new FileHubContext())
            {
                Console.Write("Getting all");
                var query = from f in db.Files
                    orderby f.Name
                    select f;

                files = query.ToList();
            }

            return files;
        }

        public async Task<FileFeDto> UploadFile(IFormFile file)
        {
            // PRE CONDITIONS
            if (file.Length <= 0) throw new Exception("Filename must exist");

            // ARRANGE
            var fileDto = new FileFeDto()
            {
                CreatedUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow,
                DeletedUtc = DateTime.MaxValue,
                Description = "This is file description",
                Id = Guid.NewGuid().ToString(),
                Name = file.FileName
            };

            var filePath = getFileFullPathById(fileDto.Id);

            // ACT
            // 1. Upload file to system
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // 2. Save a reference to DB
            using (var db = new FileHubContext())
            {
                Console.Write("Save item");
                db.Files.Add(fileDto);
                db.SaveChanges();
            }

            return fileDto;

        }

    }
}
