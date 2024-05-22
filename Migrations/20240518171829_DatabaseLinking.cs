using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class DatabaseLinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Rooms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Rooms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ListingId",
                table: "Users",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ItemId",
                table: "Rooms",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ListingId",
                table: "Rooms",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Items_ItemId",
                table: "Rooms",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Listings_ListingId",
                table: "Rooms",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Listings_ListingId",
                table: "Users",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Items_ItemId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Listings_ListingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Listings_ListingId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ListingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ItemId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ListingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Rooms");
        }
    }
}
