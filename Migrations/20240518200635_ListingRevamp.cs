using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class ListingRevamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Users",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                newName: "IX_Users_OrdersId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Listings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Listings",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Listings",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<bool>(
                name: "IsLeasable",
                table: "Listings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Listings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemListing",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "integer", nullable: false),
                    ListingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemListing", x => new { x.ItemsId, x.ListingsId });
                    table.ForeignKey(
                        name: "FK_ItemListing_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemListing_Listings_ListingsId",
                        column: x => x.ListingsId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "IsLeasable", "Price", "Title" },
                values: new object[] { "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", true, 39.99m, "Room 1" });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "IsLeasable", "Price", "Title" },
                values: new object[] { "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", true, 49.99m, "Room 2" });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Price", "Title" },
                values: new object[] { "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", 59.99m, "Room 3" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PaymentTypeId", "RoomId", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, "jordancarter@test.com", "Jordan", "Carter", 1, 1, 30.00m, 1 },
                    { 2, "postmalone@gmail.com", "Austin", "Post", 2, 3, 489.38m, 2 },
                    { 3, "jenjo@gmail.com", "Jen", "Jones", 3, 2, 89.83m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_OrdersId",
                table: "Listings",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemListing_ListingsId",
                table: "ItemListing",
                column: "ListingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Orders_OrdersId",
                table: "Listings",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrdersId",
                table: "Users",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Orders_OrdersId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrdersId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ItemListing");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Listings_OrdersId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "IsLeasable",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Users",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrdersId",
                table: "Users",
                newName: "IX_Users_RoomId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Listings",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Listings",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Listings",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsLeasable = table.Column<bool>(type: "boolean", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    ListingId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "PaymentTypeId", "RoomId", "Total" },
                values: new object[] { "jordancarter@test.com", "Jordan", "Carter", 1, 1, 30.00m });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "PaymentTypeId", "RoomId", "Total" },
                values: new object[] { "postmalone@gmail.com", "Austin", "Post", 2, 3, 489.38m });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName", "PaymentTypeId", "RoomId", "Total" },
                values: new object[] { "jenjo@gmail.com", "Jen", "Jones", 3, 2, 89.83m });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageUrl", "IsLeasable", "ItemId", "ListingId", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", true, null, null, 39.99m, "Room 1", 1 },
                    { 2, "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", true, null, null, 49.99m, "Room 2", 2 },
                    { 3, "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", false, null, null, 59.99m, "Room 3", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ItemId",
                table: "Rooms",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ListingId",
                table: "Rooms",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
