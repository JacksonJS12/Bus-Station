using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homies.Data.Migrations
{
    public partial class addNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Description", "End", "Name", "OrganiserId", "Start" },
                values: new object[] { new Guid("723d86de-3d9a-44cf-8d41-4d7df6ec57d6"), 3, "Enjoy the taste of world's kitchen in your local park.", new DateTime(2023, 10, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Cultural Food Fest", "f372d108-000b-4823-85f8-4b852cafda67", new DateTime(2023, 10, 13, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Description", "End", "Name", "OrganiserId", "Start" },
                values: new object[] { new Guid("7406248b-1808-4e40-b1c2-858679230269"), 2, "Local teen bands hosting a concert to help their teacher pay for his cancer treatment.", new DateTime(2023, 11, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), "Charity Concert", "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a", new DateTime(2023, 11, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("723d86de-3d9a-44cf-8d41-4d7df6ec57d6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("7406248b-1808-4e40-b1c2-858679230269"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
