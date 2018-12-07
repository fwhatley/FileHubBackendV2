using FileHubBackendV2.Repositories;
using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileHubBackendV2.App.FileRecords
{
    /// <summary>
    /// Ef: stands for entity framework. We can switch back to using EF and MSqlServer by injecting this class and using migrations
    /// Pg: stands for postgress
    /// The reason we are not using EF is because .net core 2.1 doesn't support postgress asof 10/4/2018
    /// Instead we are using OrmLite.PostgresSQL.Core 5.4
    /// </summary>
    public class FileRecordsPgRepository : IFileRecordsRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public FileRecordsPgRepository(IHostingEnvironment environment, IDbConnectionFactory dbConnectionFactory, IConfiguration configuration)
        {
            _hostingEnvironment = environment;
            _dbConnectionFactory = dbConnectionFactory;
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("ApplicationBaseUrl");
        }

        public FileRecord GetFileRecord(Guid id)
        {
            FileRecord fileRecord;
            using (var db = _dbConnectionFactory.Open())
            {
                var query = db.Select<FileRecord>(f => f.Id == id); //SELECT by typed expression  
                fileRecord = query.FirstOrDefault();
            }

            if (fileRecord == null)
            {
                Console.WriteLine($"WARNING - FileRecord with id doesn't exist: {id}");
            }


            return fileRecord;
        }

        public IEnumerable<FileRecord> GetFileRecords()
        {
            // retrieve the file just to get the file name
            IEnumerable<FileRecord> fileRecords;
            using (var db = _dbConnectionFactory.Open())
            {
                var query = db.Select<FileRecord>(); //SELECT by typed expression  
                fileRecords = query.ToList();
            }

            // PRE-CONDITION
            if (!fileRecords.Any()) Console.WriteLine($"INFO - zero files returned from db");

            return fileRecords;
        }

        public FileRecord CreateFileRecord(FileRecord fileRecord)
        {
            // ARRANGE
            // ACT
            // 1. Save a reference to DB
            using (var db = _dbConnectionFactory.Open())
            {
                db.Insert(fileRecord);
            }

            // POST-CONDITION
            // The insert above should have given the POCO an guid automatically
            // Check that the GUID is unique, and it's not the default Guid. Default guid for new Guid() is "00000000-0000-0000-0000-000000000000"
            if (fileRecord.Id == Guid.Empty)
                Console.WriteLine($"WARNING - filerecord guid cannot be {new Guid().ToString()}. Most likely file didn't get inserted in the DB");

            return fileRecord;
        }

    }
}
