using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReDoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3_EditContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Contacts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Contacts");
        }
    }
}
