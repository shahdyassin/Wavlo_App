using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wavlo.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNamePropertyinChatUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "ChatUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "ChatUsers");
        }
    }
}
