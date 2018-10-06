using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FileHubBackendV2.Migrations
{
    public partial class RenameDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 34, 8, 977, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 34, 8, 979, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 31, 49, 156, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedUtc", "DeletedUtc", "UpdatedUtc" },
                values: new object[] { new DateTime(2018, 10, 6, 13, 31, 49, 157, DateTimeKind.Local), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified) });
        }
    }
}
