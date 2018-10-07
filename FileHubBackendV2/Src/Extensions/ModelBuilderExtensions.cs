using System;
using FileHubBackendV2.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace FileHubBackendV2.Src.Extensions
{
    /// <summary>
    /// Tip from https://www.learnentityframeworkcore.com/migrations/seeding
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileFeDto>().HasData(
                new FileFeDto
                {
                    Id = "1",
                    Description = "Description 1",
                    Name = "name 1",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto
                {
                    Id = "2",
                    Description = "Description 2",
                    Name = "name 2",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue

                },
                new FileFeDto
                {
                    Id = "3",
                    Description = "Description 3",
                    Name = "name 3",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto
                {
                    Id = "4",
                    Description = "Description 4",
                    Name = "name 4",
                    Url = "https://via.placeholder.com/350x150",
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                },
                new FileFeDto
                {
                    Id = "5",
                    Description = "Description 5",
                    Name = "name 5",
                    Url = "https://via.placeholder.com/350x150",
                    //tags = new List<string>(){"FC", "Aesop"},
                    CreatedUtc = DateTime.Now,
                    UpdatedUtc = DateTime.MaxValue,
                    DeletedUtc = DateTime.MaxValue
                }
            );
        }
    }
}
