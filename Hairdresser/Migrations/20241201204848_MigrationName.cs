using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hairdresser.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "personnelEmail",
                table: "personnels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personnelPassword",
                table: "personnels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "personnelEmail",
                table: "personnels");

            migrationBuilder.DropColumn(
                name: "personnelPassword",
                table: "personnels");
        }
    }
}
