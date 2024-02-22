using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrisisManagementSystem.API.Migrations
{
    public partial class IncidentSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[] { 1, "", "Ceo", "ThomasRay" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[] { 2, "", "Excecutive", "JhonDoe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[] { 3, "", "Receptionist", "JaneDoe" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "Descripton", "IncidentTypeId", "Location", "Name", "ReporterId" },
                values: new object[] { 1, "very exapansive", 0, "MainBuilding", "fire in office", 1 });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "Descripton", "IncidentTypeId", "Location", "Name", "ReporterId" },
                values: new object[] { 2, "very exapansive", 0, "Whole", "Flood in office", 1 });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "Descripton", "IncidentTypeId", "Location", "Name", "ReporterId" },
                values: new object[] { 3, "very exapansive", 0, "Whole", "CyberAttack", 1 });

            migrationBuilder.InsertData(
                table: "IncidentMedia",
                columns: new[] { "Id", "IncidentId", "MediaType", "Path" },
                values: new object[,]
                {
                    { 1, 1, 0, "/Crisis/Images/image1.jpg" },
                    { 2, 1, 0, "/Crisis/Images/image2.jpg" },
                    { 3, 1, 0, "/Crisis/Images/image3.jpg" },
                    { 4, 1, 0, "/Crisis/Images/image4.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncidentMedia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncidentMedia",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncidentMedia",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncidentMedia",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
