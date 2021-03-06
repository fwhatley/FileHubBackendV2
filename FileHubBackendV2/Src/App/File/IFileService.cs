﻿using FileHubBackendV2.Src.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileHubBackendV2.Services
{
    public interface IFilesService
    {
        FhFile GetFile(Guid id);
        IEnumerable<FhFile> GetFiles();
        Task<FhFile> CreateFile(IFormFile formFile, FhFile file);
        FileDownloadDto GetFileDownloadStreamById(Guid id);
    }
}
