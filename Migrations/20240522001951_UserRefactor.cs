using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class UserRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRoom_Rooms_ListingsId",
                table: "ItemRoom");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ListingsId",
                table: "ItemRoom",
                newName: "RoomsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRoom_ListingsId",
                table: "ItemRoom",
                newName: "IX_ItemRoom_RoomsId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "jordancarter@test.com", "Jordan", "Carter" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "postmalone@gmail.com", "Austin", "Post" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "jenjo@gmail.com", "Jen", "Jones" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRoom_Rooms_RoomsId",
                table: "ItemRoom",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRoom_Rooms_RoomsId",
                table: "ItemRoom");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "ItemRoom",
                newName: "ListingsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRoom_RoomsId",
                table: "ItemRoom",
                newName: "IX_ItemRoom_ListingsId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "jordancarter@test.com", "Jordan", "Carter" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "postmalone@gmail.com", "Austin", "Post" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "jenjo@gmail.com", "Jen", "Jones" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRoom_Rooms_ListingsId",
                table: "ItemRoom",
                column: "ListingsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
