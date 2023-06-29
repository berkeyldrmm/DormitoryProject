using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dataseeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "Id", "Cost", "ExpiresDate", "Month" },
                values: new object[,]
                {
                    { 1, 750m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "September" },
                    { 2, 1500m, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "October" },
                    { 3, 1500m, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "November" },
                    { 4, 1500m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "December" },
                    { 5, 1500m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "January" },
                    { 6, 1500m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "February" },
                    { 7, 1500m, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "March" },
                    { 8, 1500m, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "April" },
                    { 9, 1500m, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "May" },
                    { 10, 750m, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "June" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
