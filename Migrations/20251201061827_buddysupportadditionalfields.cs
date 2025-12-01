using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomadBuddy00.Migrations
{
    /// <inheritdoc />
    public partial class buddysupportadditionalfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOnDate",
                table: "BuddySupportSessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "BuddySupportSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptedOnDate",
                table: "BuddySupportRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedOnDate",
                table: "BuddySupportRequests",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedOnDate",
                table: "BuddySupportSessions");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "BuddySupportSessions");

            migrationBuilder.DropColumn(
                name: "AcceptedOnDate",
                table: "BuddySupportRequests");

            migrationBuilder.DropColumn(
                name: "RejectedOnDate",
                table: "BuddySupportRequests");
        }
    }
}
