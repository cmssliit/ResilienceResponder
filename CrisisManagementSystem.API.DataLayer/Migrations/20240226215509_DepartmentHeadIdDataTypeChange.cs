using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrisisManagementSystem.API.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentHeadIdDataTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e08f5e3-500d-446c-ba99-3fc93575ee5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c04ab663-0eb5-452d-aa29-9fdc410ff543");

            migrationBuilder.AlterColumn<string>(
                name: "DeptHeadId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "573b9b58-a56f-4bed-b11e-11f0ad83091e", null, "Administrator", "ADMINISTRATOR" },
                    { "9c4cf740-a4c5-4ec5-879b-f71f9b5bd139", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573b9b58-a56f-4bed-b11e-11f0ad83091e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c4cf740-a4c5-4ec5-879b-f71f9b5bd139");

            migrationBuilder.AlterColumn<int>(
                name: "DeptHeadId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e08f5e3-500d-446c-ba99-3fc93575ee5f", null, "Administrator", "ADMINISTRATOR" },
                    { "c04ab663-0eb5-452d-aa29-9fdc410ff543", null, "User", "User" }
                });
        }
    }
}
