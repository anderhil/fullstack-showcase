using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingsDeposits.Migrations
{
    public partial class SavingsDeposit_LastCalculation_Prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCalculation",
                table: "SavingsDeposits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LastCalculation",
                table: "SavingsDeposits");

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
        }
    }
}
