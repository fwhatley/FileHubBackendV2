using FileHubBackendV2.Models;
using System;
using System.Collections.Generic;

namespace FileHubBackendV2.DataStore
{
    public class FilesDataStore
    {
        public static FilesDataStore Current { get;  } = new FilesDataStore();
        public List<FileDto> Files { get; set; }

        public FilesDataStore()
        {
            Files = new List<FileDto>()
            {
                new FileDto()
                {
                    Id = 1,
                    Description = "Description 1",
                    Name = "name 1",
                    Url = "https://via.placeholder.com/350x150",
                    tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileDto()
                {
                    Id = 2,
                    Description = "Description 2",
                    Name = "name 2",
                    Url = "https://via.placeholder.com/350x150",
                    tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue

                },
                new FileDto()
                {
                    Id = 3,
                    Description = "Description 3",
                    Name = "name 3",
                    Url = "https://via.placeholder.com/350x150",
                    tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileDto()
                {
                    Id = 4,
                    Description = "Description 4",
                    Name = "name 4",
                    Url = "https://via.placeholder.com/350x150",
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileDto()
                {
                    Id = 5,
                    Description = "Description 5",
                    Name = "name 5",
                    Url = "https://via.placeholder.com/350x150",
                    tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                }
            };
        }

    }
}
