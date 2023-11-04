using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReDoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_addedImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Instruments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Instruments");
        }
    }
}
