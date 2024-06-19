using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class RoomTagLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Rooms_RoomId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_RoomId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "RoomTag",
                columns: table => new
                {
                    RoomsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTag", x => new { x.RoomsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_RoomTag_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTag_TagsId",
                table: "RoomTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTag");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_RoomId",
                table: "Tags",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Rooms_RoomId",
                table: "Tags",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
