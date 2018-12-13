using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class AmountBalance_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "19017164-20bc-4ec9-8324-82a159027a39", "c1a52bda-c919-4baf-849d-8f1dc2e14ecf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4003188e-550e-4332-a114-17bf1ac81fb9", "2636d571-edd7-426b-a3d8-3af9a8c8a438" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a465ea12-97e0-4738-a0e5-0bfac34feea6", "306e1380-d7a2-41d4-b14b-b0b9cb604c84" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef014296-6831-43c3-9b64-1896815f84d8", "0809d8bb-2d4c-4eb8-b657-4e1c3a903da4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed50b418-d40c-4d76-8c93-ca4e4b2195a2", "8c6b7ace-295b-4cd7-b04d-0476ce6f3113", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "166678a3-d440-4ea5-861d-8d3ddb6798a6", "05ab7f55-a648-46d8-8c63-d277cd794ae0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "166678a3-d440-4ea5-861d-8d3ddb6798a6", "05ab7f55-a648-46d8-8c63-d277cd794ae0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ed50b418-d40c-4d76-8c93-ca4e4b2195a2", "8c6b7ace-295b-4cd7-b04d-0476ce6f3113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ef014296-6831-43c3-9b64-1896815f84d8", "0809d8bb-2d4c-4eb8-b657-4e1c3a903da4" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a465ea12-97e0-4738-a0e5-0bfac34feea6", "306e1380-d7a2-41d4-b14b-b0b9cb604c84", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4003188e-550e-4332-a114-17bf1ac81fb9", "2636d571-edd7-426b-a3d8-3af9a8c8a438", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19017164-20bc-4ec9-8324-82a159027a39", "c1a52bda-c919-4baf-849d-8f1dc2e14ecf", "User", "USER" });
        }
    }
}
