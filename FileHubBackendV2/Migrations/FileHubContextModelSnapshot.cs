﻿// <auto-generated />
using System;
using FileHubBackendV2.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileHubBackendV2.Migrations
{
    [DbContext(typeof(FileHubContext))]
    partial class FileHubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileHubBackendV2.Models.CityFeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FileHubBackendV2.Models.FileFeDto", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedUtc");

                    b.Property<string>("Url");

                    b.Property<string>("tags");

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasData(
                        new { Id = "1", CreatedUtc = new DateTime(2018, 10, 6, 13, 34, 8, 977, DateTimeKind.Local), DeletedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Description = "Description 1", Name = "name 1", UpdatedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Url = "https://via.placeholder.com/350x150" },
                        new { Id = "2", CreatedUtc = new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), DeletedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Description = "Description 2", Name = "name 2", UpdatedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Url = "https://via.placeholder.com/350x150" },
                        new { Id = "3", CreatedUtc = new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), DeletedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Description = "Description 3", Name = "name 3", UpdatedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Url = "https://via.placeholder.com/350x150" },
                        new { Id = "4", CreatedUtc = new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), DeletedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Description = "Description 4", Name = "name 4", UpdatedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Url = "https://via.placeholder.com/350x150" },
                        new { Id = "5", CreatedUtc = new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), DeletedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Description = "Description 5", Name = "name 5", UpdatedUtc = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), Url = "https://via.placeholder.com/350x150" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
