﻿using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileHubBackendV2.Repositories
{
    public interface IFilesRepository
    {
        FileRecord GetFileById(Guid id);
        IEnumerable<FileRecord> GetAllFiles();
        Task<FileRecord> UploadFile(IFormFile file);
        FileDownloadDto GetFileDownloadStreamById(Guid id);
    }
}
