using FileHubBackendV2.Src.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FileHubBackendV2.Src.Extensions
{
    /// <summary>
    /// Tip from https://www.learnentityframeworkcore.com/migrations/seeding
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileRecord>().HasData(
                new FileRecord
                {
                    Id = new Guid(),
                    Description = "Description 1",
                    Name = "name 1",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord
                {
                    Id = new Guid(),
                    Description = "Description 2",
                    Name = "name 2",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue

                },
                new FileRecord
                {
                    Id = new Guid(),
                    Description = "Description 3",
                    Name = "name 3",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord
                {
                    Id = new Guid(),
                    Description = "Description 4",
                    Name = "name 4",
                    Url = "https://via.placeholder.com/350x150",
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileRecord
                {
                    Id = new Guid(),
                    Description = "Description 5",
                    Name = "name 5",
                    Url = "https://via.placeholder.com/350x150",
                    //Tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                }
            );
        }
    }
}
