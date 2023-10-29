using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReDoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                table: "Instruments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_ShoppingCartId",
                table: "Instruments",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_ShoppingCarts_ShoppingCartId",
                table: "Instruments",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_ShoppingCarts_ShoppingCartId",
                table: "Instruments");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_ShoppingCartId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Instruments");
        }
    }
}
