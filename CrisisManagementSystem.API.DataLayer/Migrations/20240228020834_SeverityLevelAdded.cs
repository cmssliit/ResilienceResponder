using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrisisManagementSystem.API.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeverityLevelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573b9b58-a56f-4bed-b11e-11f0ad83091e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c4cf740-a4c5-4ec5-879b-f71f9b5bd139");

            migrationBuilder.AddColumn<int>(
                name: "Severity",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "041d78ad-1229-4168-89a7-d5002881887d", null, "User", "User" },
                    { "e38d359f-a18e-474b-b0b6-861a9868d2d8", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "041d78ad-1229-4168-89a7-d5002881887d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e38d359f-a18e-474b-b0b6-861a9868d2d8");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Incidents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "573b9b58-a56f-4bed-b11e-11f0ad83091e", null, "Administrator", "ADMINISTRATOR" },
                    { "9c4cf740-a4c5-4ec5-879b-f71f9b5bd139", null, "User", "User" }
                });
        }
    }
}
