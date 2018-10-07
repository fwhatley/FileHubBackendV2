using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;
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

        public FilesPgRepository(IHostingEnvironment environment, IDbConnectionFactory dbConnectionFactory)
        {
            _hostingEnvironment = environment;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public FileRecord GetFileById(Guid id)
        {
            FileRecord fileRecord = new FileRecord();;
            using (var db = _dbConnectionFactory.Open())
            {
                var fileRecords = db.Select<FileRecord>(f => f.Id == id); //SELECT by typed expression  
                $"Number of rows with id={1}: {fileRecords.Count}".PrintDump();

                fileRecord = fileRecords.FirstOrDefault();
            }

            return fileRecord;
        }

        public FileDownloadDto GetFileDownloadStreamById(Guid id)
        {
            throw new NotImplementedException();
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

            var pathToUploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, FhConstants.UploadsFolderName);
            var filePath = Path.Combine(pathToUploadFolder, id.ToString());
            return filePath;
        }

        public IEnumerable<FileRecord> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public async Task<FileRecord> UploadFile(IFormFile file)
        {
            throw new NotImplementedException();

        }

    }
}
