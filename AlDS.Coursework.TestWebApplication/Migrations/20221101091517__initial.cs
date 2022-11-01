using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlDS.Coursework.TestWebApplication.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Space = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Information = table.Column<string>(type: "nvarchar(253)", maxLength: 253, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateBirthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBoards",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoards", x => new { x.UserId, x.BoardId });
                    table.ForeignKey(
                        name: "FK_UserBoards_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBoards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(257)", maxLength: 257, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserExecuted = table.Column<int>(type: "int", nullable: true),
                    DateExecuted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_BoardId",
                table: "Boards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BoardId",
                table: "Cards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardId",
                table: "Cards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CardId",
                table: "Notes",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteId",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoards_BoardId",
                table: "UserBoards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "UserBoards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
