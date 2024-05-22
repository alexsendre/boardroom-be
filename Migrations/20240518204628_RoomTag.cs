using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class RoomTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ListingId",
                table: "Tags",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Listings_ListingId",
                table: "Tags",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Listings_ListingId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ListingId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Tags");
        }
    }
}
