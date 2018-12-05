using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class SeedAppRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20bfb22e-1233-432e-9d20-79fc8ea043dc", "db26299d-0834-48ad-9ec2-690b580ac698", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84f84330-b76c-4d7f-8fd7-5c0daab92ce3", "2ca036cf-8610-4420-b96c-6d39a69dfe47", "Manager", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f30310f7-7004-43a0-b6ec-4f2ffe84e096", "bcf4e3b3-0106-4d20-8797-babbde28377f", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "20bfb22e-1233-432e-9d20-79fc8ea043dc", "db26299d-0834-48ad-9ec2-690b580ac698" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "84f84330-b76c-4d7f-8fd7-5c0daab92ce3", "2ca036cf-8610-4420-b96c-6d39a69dfe47" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f30310f7-7004-43a0-b6ec-4f2ffe84e096", "bcf4e3b3-0106-4d20-8797-babbde28377f" });

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
    }
}
