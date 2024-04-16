using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insta.Data.Migrations
{
    /// <inheritdoc />
    public partial class postPPL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagedPeople",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagedPeople",
                table: "Posts");
        }
    }
}
