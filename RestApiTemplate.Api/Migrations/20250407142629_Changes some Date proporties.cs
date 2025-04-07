using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiTemplate.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangessomeDateproporties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Templates",
                newName: "DateTimeCreated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Templates",
                newName: "DateOnlyCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "Templates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "Templates",
                newName: "TimeCreated");

            migrationBuilder.RenameColumn(
                name: "DateOnlyCreated",
                table: "Templates",
                newName: "DateCreated");
        }
    }
}
