using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class BoolChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHost",
                table: "Users",
                newName: "IsSeller");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "Rooms",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "Items",
                newName: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSeller",
                table: "Users",
                newName: "IsHost");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Rooms",
                newName: "HostId");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Items",
                newName: "HostId");
        }
    }
}
