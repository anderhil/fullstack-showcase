using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class FixRoleNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8c5e61ed-010b-401e-b361-7ddeef5a6c89", "0ff3a047-bce6-4b4d-a2a9-0ea688e1f201", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1c8b800-8690-4eda-ae5e-237ec1e431be", "a70b291c-8115-469d-a90a-ae4f9bb08063", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0ad6c96-92d0-403b-b52a-3c348b1e9e75", "0b46f3ca-cb9b-4319-b482-d4e2dd8a236c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8c5e61ed-010b-401e-b361-7ddeef5a6c89", "0ff3a047-bce6-4b4d-a2a9-0ea688e1f201" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b1c8b800-8690-4eda-ae5e-237ec1e431be", "a70b291c-8115-469d-a90a-ae4f9bb08063" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c0ad6c96-92d0-403b-b52a-3c348b1e9e75", "0b46f3ca-cb9b-4319-b482-d4e2dd8a236c" });

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
    }
}
