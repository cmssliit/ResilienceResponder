using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrisisManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DefaultRoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51001771-3fed-4995-b94c-589e4b29d97a", null, "Administrator", "ADMINISTRATOR" },
                    { "ffcb0a9f-239d-45f0-abb2-59e236be7de0", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51001771-3fed-4995-b94c-589e4b29d97a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcb0a9f-239d-45f0-abb2-59e236be7de0");
        }
    }
}
