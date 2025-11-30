using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomadBuddy00.Migrations
{
    /// <inheritdoc />
    public partial class AddedBuddySupportModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuddySupportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<int>(type: "int", nullable: false),
                    NomadUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportRequests_BuddySupports_BuddySupportId",
                        column: x => x.BuddySupportId,
                        principalTable: "BuddySupports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportRequests_Nomads_NomadUserId",
                        column: x => x.NomadUserId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportRequestId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionStatus = table.Column<int>(type: "int", nullable: false),
                    OptionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_BuddySupportRequests_BuddySupportRequestId",
                        column: x => x.BuddySupportRequestId,
                        principalTable: "BuddySupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportSessionId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_BuddySupportSessions_BuddySupportSessionId",
                        column: x => x.BuddySupportSessionId,
                        principalTable: "BuddySupportSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_BuddyId",
                table: "BuddySupportRatings",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_BuddySupportSessionId",
                table: "BuddySupportRatings",
                column: "BuddySupportSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_NomadId",
                table: "BuddySupportRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRequests_BuddySupportId",
                table: "BuddySupportRequests",
                column: "BuddySupportId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRequests_NomadUserId",
                table: "BuddySupportRequests",
                column: "NomadUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_BuddyId",
                table: "BuddySupportSessions",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_BuddySupportRequestId",
                table: "BuddySupportSessions",
                column: "BuddySupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_NomadId",
                table: "BuddySupportSessions",
                column: "NomadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuddySupportRatings");

            migrationBuilder.DropTable(
                name: "BuddySupportSessions");

            migrationBuilder.DropTable(
                name: "BuddySupportRequests");
        }
    }
}
