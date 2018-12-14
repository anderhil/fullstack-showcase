using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class ReportData_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "TotalProfitBeforeTax",
                table: "DepositsHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalProfitTax",
                table: "DepositsHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    JsonObject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

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

            migrationBuilder.DropColumn(
                name: "TotalProfitBeforeTax",
                table: "DepositsHistory");

            migrationBuilder.DropColumn(
                name: "TotalProfitTax",
                table: "DepositsHistory");

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
    }
}
