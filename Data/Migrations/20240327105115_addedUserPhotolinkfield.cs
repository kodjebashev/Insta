using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insta.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedUserPhotolinkfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoLink",
                table: "AppUsers");
        }
    }
}
