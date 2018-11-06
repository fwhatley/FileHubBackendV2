using FileHubBackendV2.Src.Models;
using System;
using System.Collections.Generic;

namespace FileHubBackendV2.Services
{
    public interface IFileRecordsService
    {
        FileRecord GetFileRecordById(Guid id);
        IEnumerable<FileRecord> GetFileRecords();
        FileRecord CreateFileRecord(FileRecord fileRecord);
    }
}
