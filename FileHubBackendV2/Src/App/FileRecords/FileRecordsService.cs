using FileHubBackendV2.Repositories;
using FileHubBackendV2.Src.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileHubBackendV2.Services
{
    public class FileRecordsService: IFileRecordsService
    {
        private readonly IFileRecordsRepository _fileRecordsRepository;
        private readonly IFilesRepository _fileRepository;
        private readonly string _baseUrl;

        public FileRecordsService(IFileRecordsRepository fileRecordsRepository, IFilesRepository filesRepository, IConfiguration configuration)
        {
            _fileRecordsRepository = fileRecordsRepository;
            _fileRepository = filesRepository;
            _baseUrl = configuration.GetValue<string>("ApplicationBaseUrl");
        }

        public FileRecord GetFileRecord(Guid id)
        {
            var files = _fileRepository.GetFiles().ToList();
            var fileRecord = _fileRecordsRepository.GetFileRecord(id);

            // add download url to fileRecord
            foreach (var f in files)
            {
                if (f.FileRecordId == fileRecord.Id)
                {
                    fileRecord.Url = $"/api/files/downloadFile/{f.Id}"; // builds a url like this /api/files/fileId
                    break;
                }
            }

            return fileRecord;
        }

        public IEnumerable<FileRecord> GetFileRecords()
        {
            var fileRecords = _fileRecordsRepository.GetFileRecords().ToList();
            var files = _fileRepository.GetFiles().ToList();

            // add download url to fileRecords
            foreach (var fr in fileRecords)
            {
                foreach (var f in files)
                {
                    // provide different base urls depending in environment
                    if (fr.Id == f.FileRecordId)
                    {
                        fr.Url = $"/api/files/downloadFile/{f.Id}"; // builds a url like this /api/files/fileId
                        break;
                    }
                }
            }

            return fileRecords;
        }

        public FileRecord CreateFileRecord(FileRecord fileRecord)
        {
            return _fileRecordsRepository.CreateFileRecord(fileRecord);
        }
    }
}
