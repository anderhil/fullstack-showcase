using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class Unique_Bank_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2314e8a7-7438-497e-bfa6-50169674365a", "a35fc5a5-7360-4a48-a694-5efe2a4385b2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bf1112b6-bac9-4467-9268-c50318941077", "c043333e-e940-4fbf-b57c-71529fbfc687" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d311282c-652e-4ace-b931-b9cc8175e44d", "2537090e-60ac-4963-ae20-cb73b52dd56e" });

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "SavingsDeposits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SavingsDeposits_BankName_AccountNumber",
                table: "SavingsDeposits",
                columns: new[] { "BankName", "AccountNumber" },
                unique: true,
                filter: "[BankName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingsDeposits_BankName_AccountNumber",
                table: "SavingsDeposits");

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

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "SavingsDeposits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2314e8a7-7438-497e-bfa6-50169674365a", "a35fc5a5-7360-4a48-a694-5efe2a4385b2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d311282c-652e-4ace-b931-b9cc8175e44d", "2537090e-60ac-4963-ae20-cb73b52dd56e", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf1112b6-bac9-4467-9268-c50318941077", "c043333e-e940-4fbf-b57c-71529fbfc687", "User", "USER" });
        }
    }
}
