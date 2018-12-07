using System;
using System.Collections.Generic;
using FileHubBackendV2.Src.Models;

namespace FileHubBackendV2.Repositories
{
    public interface IFileRecordsRepository
    {
        FileRecord GetFileRecord(Guid id);
        IEnumerable<FileRecord> GetFileRecords();
        FileRecord CreateFileRecord(FileRecord fileRecord);
    }
}
