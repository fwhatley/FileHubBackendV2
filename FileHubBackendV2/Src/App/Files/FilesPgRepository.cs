﻿using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileHubBackendV2.Repositories
{
    /// <summary>
    /// Ef: stands for entity framework. We can switch back to using EF and MSqlServer by injecting this class and using migrations
    /// Pg: stands for postgress
    /// The reason we are not using EF is because .net core 2.1 doesn't support postgress asof 10/4/2018
    /// Instead we are using OrmLite.PostgresSQL.Core 5.4
    /// </summary>
    public class FilesPgRepository : IFilesRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public FilesPgRepository(IHostingEnvironment environment, IDbConnectionFactory dbConnectionFactory, IConfiguration configuration)
        {
            _hostingEnvironment = environment;
            _dbConnectionFactory = dbConnectionFactory;
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("ApplicationBaseUrl");
        }

        public FileRecord GetFileById(Guid id)
        {
            FileRecord fileRecord;
            using (var db = _dbConnectionFactory.Open())
            {
                var query = db.Select<FileRecord>(f => f.Id == id); //SELECT by typed expression  
                fileRecord = query.FirstOrDefault();
            }

            return fileRecord;
        }

        public FileDownloadDto GetFileDownloadStreamById(Guid id)
        {
            // retrieve the file just to get the file name
            FileRecord fileRecord;
            using (var db = _dbConnectionFactory.Open())
            {
                var query = db.Select<FileRecord>(f => f.Id == id); //SELECT by typed expression  
                fileRecord = query.FirstOrDefault();
            }

            // PRE-CONDITION
            // As a rule of thumb exception checks are done in the controller. 
            // doing this here because we have to use the fileRecord.Name to buid the object
            if (string.IsNullOrEmpty(fileRecord?.Name))
                throw new Exception("filerecord doesn't exist when it should");

            // build file to download, include stream and filename
            FileDownloadDto fileDownloadDto = new FileDownloadDto
            {
                FileName = fileRecord.Name,
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
        private MemoryStream getFileDataStream(Guid id)
        {
            var fullFilePath = getFileFullPathById(id);
            
            //converting file into bytes array  
            var dataBytes = File.ReadAllBytes(fullFilePath);
            
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);
            return dataStream;
        }

        private string getFileFullPathById(Guid id)
        {
            // prevent null reference in linux: https://stackoverflow.com/questions/35322136/ihostingenvironment-webrootpath-is-null-when-using-ef7-commands
            // in linux webrootpath will be null
            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = "/var/FileHubBackendV2/wwwroot"; // TODO: hard code the path for linux for now. Needs to change bc it will break if app gets deployed to a different folder
                Console.WriteLine($"WARNING - _hostingEnvironment.WebRootPath was null or empty. Using hardcoded value: {_hostingEnvironment.WebRootPath}");
            }

            var folderName = _configuration.GetValue<string>("Data:UploadsFolderName");

            var pathToUploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            var filePath = Path.Combine(pathToUploadFolder, id.ToString());
            return filePath;
        }

        public IEnumerable<FileRecord> GetAllFiles()
        {
            // retrieve the file just to get the file name
            IEnumerable<FileRecord> fileRecords;
            using (var db = _dbConnectionFactory.Open())
            {
                var query = db.Select<FileRecord>(); //SELECT by typed expression  
                fileRecords = query.ToList();
            }

            // PRE-CONDITION
            if (fileRecords == null) throw new Exception("files couldn't be retrieved from the db");

            // add urls to the file for download
            foreach (var fileRecord in fileRecords)
            {
                var fullPathToFile = $"{baseUrl}/api/files/downloadFile/{fileRecord.Id}";
                fileRecord.Url = fullPathToFile;
            }

            return fileRecords;
        }
        
        public async Task<FileRecord> UploadFile(IFormFile file)
        {
            // ARRANGE
            var fileRecord = new FileRecord()
            {
                CreatedUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow,
                DeletedUtc = DateTime.MaxValue,
                Description = "filerecordpgrepo.uploadfile(): This is file description",
                Name = file.FileName,
                // Id is autogenerated and assigned to POCO by postgres on insert/save: https://github.com/ServiceStack/ServiceStack.OrmLite#auto-populated-guid-ids
            };

            // ACT
            // 1. Save a reference to DB
            using (var db = _dbConnectionFactory.Open())
            {
                db.Insert(fileRecord);
            }

            // PRE-CONDITION
            // The insert above should have given the POCO an guid automatically
            // Check that the GUID is unique, and it's not the default Guid. Default guid for new Guid() is "00000000-0000-0000-0000-000000000000"
            if (fileRecord.Id == new Guid())
                throw new Exception("filerecord guid cannot be 00000000-0000-0000-0000-000000000000. Most likely file didn't get inserted in the DB");

            // 2. Upload file to system
            var filePath = getFileFullPathById(fileRecord.Id);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // update data to return with url
            fileRecord.Url = $"{baseUrl}/api/files/downloadFile/{fileRecord.Id}";
            return fileRecord;
        }

    }
}
