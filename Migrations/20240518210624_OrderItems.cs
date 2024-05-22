using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class OrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrdersId",
                table: "Items",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrdersId",
                table: "Items",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrdersId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrdersId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Items");
        }
    }
}
