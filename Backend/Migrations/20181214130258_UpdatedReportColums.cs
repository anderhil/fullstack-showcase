using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class UpdatedReportColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "494f09f9-bf93-414d-a404-e2111f95532e", "5c4d00a9-ca83-40af-80ac-55edfb2673ed" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5907f4c7-ecd3-45f5-9317-aee0a882367d", "c02f3706-eb75-43c6-b7f0-c89add5b3877" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "894c95ae-1b1f-44e0-92e8-d0a0a4e8e05d", "148b5a04-0b65-46fb-b3e9-d2943e1cc3f3" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d25f252-d364-43f4-a8f3-984939462580", "96534391-f7d1-4ef8-84a2-b76e2c27e873", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1164d87a-9b5e-4ec0-aae9-1a72c87c47f8", "2f1e448f-37d6-4e37-b195-385bd648df2f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c951f55-16a7-431e-bb14-03fd0299880a", "d25dd80b-69c6-4bd5-9030-f99f27c60287", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0d25f252-d364-43f4-a8f3-984939462580", "96534391-f7d1-4ef8-84a2-b76e2c27e873" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1164d87a-9b5e-4ec0-aae9-1a72c87c47f8", "2f1e448f-37d6-4e37-b195-385bd648df2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3c951f55-16a7-431e-bb14-03fd0299880a", "d25dd80b-69c6-4bd5-9030-f99f27c60287" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "894c95ae-1b1f-44e0-92e8-d0a0a4e8e05d", "148b5a04-0b65-46fb-b3e9-d2943e1cc3f3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5907f4c7-ecd3-45f5-9317-aee0a882367d", "c02f3706-eb75-43c6-b7f0-c89add5b3877", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "494f09f9-bf93-414d-a404-e2111f95532e", "5c4d00a9-ca83-40af-80ac-55edfb2673ed", "User", "USER" });
        }
    }
}
