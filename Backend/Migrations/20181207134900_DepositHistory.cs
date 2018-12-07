using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class DepositHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingDeposit_AspNetUsers_Owner",
                table: "SavingDeposit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingDeposit",
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

            migrationBuilder.RenameTable(
                name: "SavingDeposit",
                newName: "SavingsDeposits");

            migrationBuilder.RenameIndex(
                name: "IX_SavingDeposit_Owner",
                table: "SavingsDeposits",
                newName: "IX_SavingsDeposits_Owner");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentProfitAfterTax",
                table: "SavingsDeposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsDeposits",
                table: "SavingsDeposits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DepositsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SavingsDepositId = table.Column<int>(nullable: false),
                    CalculationDate = table.Column<DateTime>(nullable: false),
                    TotalProfitAfterTax = table.Column<decimal>(nullable: false),
                    ProfitTax = table.Column<decimal>(nullable: false),
                    ProfitBeforeTax = table.Column<decimal>(nullable: false),
                    ProfitAfterTax = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositsHistory_SavingsDeposits_SavingsDepositId",
                        column: x => x.SavingsDepositId,
                        principalTable: "SavingsDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c070170e-0bbe-4fc9-8dd4-7fbb99019fe6", "e1ec07be-97e7-465f-8ec5-1edfaea58010", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1cb0c316-241e-4bbf-95ec-e43c8c0ee018", "8bc53d14-1dac-4013-ad6f-3feb60a13b1c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "881205c3-1582-4c87-ba8c-431bece2821c", "bd765a6c-d6b1-45cb-89b3-4bd320f6716a", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_DepositsHistory_SavingsDepositId",
                table: "DepositsHistory",
                column: "SavingsDepositId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsDeposits_AspNetUsers_Owner",
                table: "SavingsDeposits",
                column: "Owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsDeposits_AspNetUsers_Owner",
                table: "SavingsDeposits");

            migrationBuilder.DropTable(
                name: "DepositsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsDeposits",
                table: "SavingsDeposits");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1cb0c316-241e-4bbf-95ec-e43c8c0ee018", "8bc53d14-1dac-4013-ad6f-3feb60a13b1c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "881205c3-1582-4c87-ba8c-431bece2821c", "bd765a6c-d6b1-45cb-89b3-4bd320f6716a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c070170e-0bbe-4fc9-8dd4-7fbb99019fe6", "e1ec07be-97e7-465f-8ec5-1edfaea58010" });

            migrationBuilder.DropColumn(
                name: "CurrentProfitAfterTax",
                table: "SavingsDeposits");

            migrationBuilder.RenameTable(
                name: "SavingsDeposits",
                newName: "SavingDeposit");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsDeposits_Owner",
                table: "SavingDeposit",
                newName: "IX_SavingDeposit_Owner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingDeposit",
                table: "SavingDeposit",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SavingDeposit_AspNetUsers_Owner",
                table: "SavingDeposit",
                column: "Owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
