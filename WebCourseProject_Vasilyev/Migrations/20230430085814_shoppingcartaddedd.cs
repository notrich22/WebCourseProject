using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebCourseProject_Vasilyev.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartaddedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingCarts_ShoppingCartId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShoppingCartId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Buyers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "OrderComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.SerialColumn),
                    itemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderComponent_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderComponent_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComponent_itemId",
                table: "OrderComponent",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComponent_OrderId",
                table: "OrderComponent",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderComponent");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Buyers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingCartId",
                table: "Items",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingCarts_ShoppingCartId",
                table: "Items",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
