using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class UserOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "OrderUser",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderUser", x => new { x.OrdersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_OrderUser_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderUser_UsersId",
                table: "OrderUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderUser");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrderId",
                table: "Users",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
