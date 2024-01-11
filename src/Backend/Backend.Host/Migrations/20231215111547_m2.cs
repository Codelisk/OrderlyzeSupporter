using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Host.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answers",
                table: "correctConversationPartEntity",
                newName: "Answer");

            migrationBuilder.RenameColumn(
                name: "Answers",
                table: "aiConversationPartEntity",
                newName: "Answer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "correctConversationPartEntity",
                newName: "Answers");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "aiConversationPartEntity",
                newName: "Answers");
        }
    }
}
