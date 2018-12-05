using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class OwnerField_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "SavingDeposit",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f5dd0a6-b15b-4248-b074-1b6d17ee293d", "95ed56f9-7a4f-4ed4-ad61-0674b65b228b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6f86a8e-a3da-48d8-b2af-7cd6fdd63f15", "f18e225e-bf70-4fec-b70c-f0aadd1995c2", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88776c50-83f4-4d7f-8cea-ef97b859438c", "3fd57446-2162-4323-90ce-d335a8a6aa0e", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_SavingDeposit_Owner",
                table: "SavingDeposit",
                column: "Owner");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingDeposit_AspNetUsers_Owner",
                table: "SavingDeposit",
                column: "Owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingDeposit_AspNetUsers_Owner",
                table: "SavingDeposit");

            migrationBuilder.DropIndex(
                name: "IX_SavingDeposit_Owner",
                table: "SavingDeposit");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "88776c50-83f4-4d7f-8cea-ef97b859438c", "3fd57446-2162-4323-90ce-d335a8a6aa0e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8f5dd0a6-b15b-4248-b074-1b6d17ee293d", "95ed56f9-7a4f-4ed4-ad61-0674b65b228b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f6f86a8e-a3da-48d8-b2af-7cd6fdd63f15", "f18e225e-bf70-4fec-b70c-f0aadd1995c2" });

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "SavingDeposit",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
