using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c44607a2-a6f5-4e1c-a28a-6eebef7b420f", "bda4e13b-f6f2-4a5f-8506-122e02e3d6d8", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64950272-ac34-4a54-a3c6-0e2abeba2e9a", "f81090d4-0e9b-4d71-b2d1-eeaf455ba1cc", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "736187db-1e27-4d29-81e4-da7c0c6a10e4", "5d6ebacc-d658-4876-b5f6-cfe757c7b3d8", "usermanager", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "64950272-ac34-4a54-a3c6-0e2abeba2e9a", "f81090d4-0e9b-4d71-b2d1-eeaf455ba1cc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "736187db-1e27-4d29-81e4-da7c0c6a10e4", "5d6ebacc-d658-4876-b5f6-cfe757c7b3d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c44607a2-a6f5-4e1c-a28a-6eebef7b420f", "bda4e13b-f6f2-4a5f-8506-122e02e3d6d8" });
        }
    }
}
