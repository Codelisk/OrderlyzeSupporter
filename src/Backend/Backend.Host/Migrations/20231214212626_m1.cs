using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Host.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testEntity");

            migrationBuilder.CreateTable(
                name: "aiConversationPartEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aiConversationPartEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "correctConversationPartEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_correctConversationPartEntity", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aiConversationPartEntity");

            migrationBuilder.DropTable(
                name: "correctConversationPartEntity");

            migrationBuilder.CreateTable(
                name: "testEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testEntity", x => x.id);
                });
        }
    }
}
