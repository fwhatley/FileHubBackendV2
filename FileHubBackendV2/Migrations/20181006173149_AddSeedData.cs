using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FileHubBackendV2.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "CreatedUtc", "DeletedUtc", "Description", "Name", "UpdatedUtc", "Url", "tags" },
                values: new object[,]
                {
                    { "1", new DateTime(2018, 10, 6, 13, 31, 49, 156, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "Description 1", "name 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "https://via.placeholder.com/350x150", null },
                    { "2", new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "Description 2", "name 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "https://via.placeholder.com/350x150", null },
                    { "3", new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "Description 3", "name 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "https://via.placeholder.com/350x150", null },
                    { "4", new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "Description 4", "name 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "https://via.placeholder.com/350x150", null },
                    { "5", new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "Description 5", "name 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), "https://via.placeholder.com/350x150", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "5");
        }
    }
}
