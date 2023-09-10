using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseProject_Vasilyev.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartAndOrderUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartComponent_Items_itemId",
                table: "ShoppingCartComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartComponent_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartComponent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartComponent",
                table: "ShoppingCartComponent");

            migrationBuilder.RenameTable(
                name: "ShoppingCartComponent",
                newName: "ShoppingCartComponents");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartComponent_ShoppingCartId",
                table: "ShoppingCartComponents",
                newName: "IX_ShoppingCartComponents_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartComponent_itemId",
                table: "ShoppingCartComponents",
                newName: "IX_ShoppingCartComponents_itemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartComponents",
                table: "ShoppingCartComponents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartComponents_Items_itemId",
                table: "ShoppingCartComponents",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartComponents_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartComponents",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartComponents_Items_itemId",
                table: "ShoppingCartComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartComponents_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartComponents",
                table: "ShoppingCartComponents");

            migrationBuilder.RenameTable(
                name: "ShoppingCartComponents",
                newName: "ShoppingCartComponent");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartComponents_ShoppingCartId",
                table: "ShoppingCartComponent",
                newName: "IX_ShoppingCartComponent_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartComponents_itemId",
                table: "ShoppingCartComponent",
                newName: "IX_ShoppingCartComponent_itemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartComponent",
                table: "ShoppingCartComponent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartComponent_Items_itemId",
                table: "ShoppingCartComponent",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartComponent_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartComponent",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
