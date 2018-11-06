using FileHubBackendV2.Repositories;
using FileHubBackendV2.Src.Models;
using System;
using System.Collections.Generic;

namespace FileHubBackendV2.Services
{
    public class FileRecordsService: IFileRecordsService
    {
        private readonly IFileRecordsRepository _fileRecordsRepository;
        public FileRecordsService(IFileRecordsRepository fileRecordsRepository)
        {
            _fileRecordsRepository = fileRecordsRepository;
        }

        public FileRecord GetFileRecordById(Guid id)
        {
            return _fileRecordsRepository.GetFileRecordById(id);
        }

        public IEnumerable<FileRecord> GetFileRecords()
        {
            return _fileRecordsRepository.GetFileRecords();
        }

        public FileRecord CreateFileRecord(FileRecord fileRecord)
        {
            return _fileRecordsRepository.CreateFileRecord(fileRecord);
        }
    }
}
