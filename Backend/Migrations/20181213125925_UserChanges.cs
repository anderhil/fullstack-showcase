using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "230af803-c40c-4436-abad-0fee4e9d0ca2", "9be08327-ca25-4c14-9e0f-8a739ac8fb42" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2be1588a-25b1-47f1-a1c8-1103a4a19e1c", "059b129a-b0a6-4e5c-a65a-763e205e5cf1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2d60581e-6424-4fbe-bf91-976efa672c65", "183e3375-c476-498b-a295-98abdda2f3a1" });

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "230af803-c40c-4436-abad-0fee4e9d0ca2", "9be08327-ca25-4c14-9e0f-8a739ac8fb42", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d60581e-6424-4fbe-bf91-976efa672c65", "183e3375-c476-498b-a295-98abdda2f3a1", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2be1588a-25b1-47f1-a1c8-1103a4a19e1c", "059b129a-b0a6-4e5c-a65a-763e205e5cf1", "User", "USER" });
        }
    }
}
