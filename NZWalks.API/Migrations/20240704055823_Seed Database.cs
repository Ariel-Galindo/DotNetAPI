using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("372f2d6e-4aae-4a1b-9d16-7923849aa30a"), "Hard" },
                    { new Guid("3fa352be-d05f-49b2-8869-9c348457b68a"), "Easy" },
                    { new Guid("6870d922-614c-4e2e-8813-bd3eebe22a55"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("59639d86-3f65-4732-9d75-8d84a22e9e3f"), "US-AK", "Red Dog Airport", "http://dummyimage.com/122x100.png/dddddd/000000" },
                    { new Guid("606dbfb1-78f2-4690-92d1-0f10e7b3e4b9"), "US-IA", "Boone Municipal Airport", "http://dummyimage.com/177x100.png/ff4444/ffffff" },
                    { new Guid("60a48162-1e5d-482d-8eea-53e31463245e"), "US-GA", "Moody Air Force Base", "http://dummyimage.com/175x100.png/cc0000/ffffff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("372f2d6e-4aae-4a1b-9d16-7923849aa30a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3fa352be-d05f-49b2-8869-9c348457b68a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6870d922-614c-4e2e-8813-bd3eebe22a55"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("59639d86-3f65-4732-9d75-8d84a22e9e3f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("606dbfb1-78f2-4690-92d1-0f10e7b3e4b9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("60a48162-1e5d-482d-8eea-53e31463245e"));
        }
    }
}
