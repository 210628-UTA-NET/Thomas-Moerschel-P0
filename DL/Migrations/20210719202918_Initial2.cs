using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "LineItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "LineItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "LineItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrdersId",
                table: "LineItems",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductsId",
                table: "LineItems",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_OrdersId",
                table: "LineItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_OrdersId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_OrdersId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ProductsId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "LineItems");
        }
    }
}
