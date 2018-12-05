using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class OwnerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SavingDeposit");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "SavingDeposit",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "SavingDeposit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72e0327b-3c76-4d71-94cf-17f4aa0e71a8", "a08750ff-36d2-4d74-92c3-40ac4e44d3ca", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66544c0b-3641-4d29-b7d6-28be80a8cb8f", "3e5ebb5f-72cd-44e4-b20e-2a6b35aebeb8", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b24d3f8-dc56-4414-89d8-debaf6997c66", "768c0899-aa9d-4c02-b854-288f728cfbe8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1b24d3f8-dc56-4414-89d8-debaf6997c66", "768c0899-aa9d-4c02-b854-288f728cfbe8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "66544c0b-3641-4d29-b7d6-28be80a8cb8f", "3e5ebb5f-72cd-44e4-b20e-2a6b35aebeb8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "72e0327b-3c76-4d71-94cf-17f4aa0e71a8", "a08750ff-36d2-4d74-92c3-40ac4e44d3ca" });

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "SavingDeposit");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "SavingDeposit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SavingDeposit",
                nullable: false,
                defaultValue: 0);

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
    }
}
