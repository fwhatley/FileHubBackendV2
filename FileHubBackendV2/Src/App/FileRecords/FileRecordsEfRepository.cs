﻿using FileHubBackendV2.Repositories;
using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileHubBackendV2.App.FileRecords
{
    /// <summary>
    /// Ef: stands for entity framework. We can switch back to using EF and MSqlServer by injecting this class and using migrations
    /// Pg: stands for postgress
    /// The reason we are not using EF is because .net core 2.1 doesn't support postgress asof 10/4/2018
    /// Instead we are using OrmLite.PostgresSQL.Core 5.4
    /// </summary>
    public class FileRecordsEfRepository : IFileRecordsRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public FileRecordsEfRepository(IHostingEnvironment environment, IConfiguration configuration)
        {
            _hostingEnvironment = environment;
            _configuration = configuration;
        }

        public FileRecord GetFileRecord(Guid id)
        {
            
            FileRecord file = new FileRecord();
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

        /// <summary>
        /// returns a file stream of the identified file by id
        /// reference used: https://www.c-sharpcorner.com/article/sending-files-from-web-api/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private MemoryStream GetFileDataStream(Guid id)
        {
            var fullFilePath = GetFileFullPathById(id);
            
            //converting file into bytes array  
            var dataBytes = File.ReadAllBytes(fullFilePath);
            
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);
            return dataStream;
        }

        private string GetFileFullPathById(Guid id)
        {
            var folderName = _configuration.GetValue<string>("Data:UploadsFolderName");
            var pathToUploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            var filePath = Path.Combine(pathToUploadFolder, id.ToString());
            return filePath;
        }

        public async Task<FileRecord> UploadFile(IFormFile file)
        {
            // PRE CONDITIONS
            if (file.Length <= 0) throw new Exception("Filename must exist");

            // ARRANGE
            var fileDto = new FileRecord()
            {
                CreatedUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow,
                DeletedUtc = DateTime.MaxValue,
                Description = "This is file description",
                Name = file.FileName
            };

            var filePath = GetFileFullPathById(fileDto.Id);

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

        public FileRecord CreateFile(FileRecord fileRecord)
        {
            throw new Exception("not implemented");
        }

        public FileRecord GetFileRecordById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileRecord> GetFileRecords()
        {
            throw new NotImplementedException();
        }

        public FileRecord CreateFileRecord(FileRecord fileRecord)
        {
            throw new NotImplementedException();
        }
    }
}
