using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class ListingRebrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Listings_ListingId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Listings_ListingId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrdersId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ItemListing");

            migrationBuilder.DropTable(
                name: "ItemOrders");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Users",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ListingId",
                table: "Users",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrdersId",
                table: "Users",
                newName: "IX_Users_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ListingId",
                table: "Users",
                newName: "IX_Users_OrderId");

            migrationBuilder.RenameColumn(
                name: "ListingId",
                table: "Tags",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ListingId",
                table: "Tags",
                newName: "IX_Tags_RoomId");

            migrationBuilder.CreateTable(
                name: "ItemOrder",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "integer", nullable: false),
                    OrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrder", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_ItemOrder_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    HostId = table.Column<int>(type: "integer", nullable: false),
                    IsLeasable = table.Column<bool>(type: "boolean", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemRoom",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "integer", nullable: false),
                    ListingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRoom", x => new { x.ItemsId, x.ListingsId });
                    table.ForeignKey(
                        name: "FK_ItemRoom_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRoom_Rooms_ListingsId",
                        column: x => x.ListingsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HostId", "ImageUrl", "IsLeasable", "OrderId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", true, null, 39.99m, "Room 1" },
                    { 2, 2, "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", true, null, 49.99m, "Room 2" },
                    { 3, 3, "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", false, null, 59.99m, "Room 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_OrdersId",
                table: "ItemOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRoom_ListingsId",
                table: "ItemRoom",
                column: "ListingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OrderId",
                table: "Rooms",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Rooms_RoomId",
                table: "Tags",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users",
                column: "OrderId",
                principalTable: "Orders",
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
                name: "FK_Tags_Rooms_RoomId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ItemOrder");

            migrationBuilder.DropTable(
                name: "ItemRoom");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Users",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Users",
                newName: "ListingId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                newName: "IX_Users_OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrderId",
                table: "Users",
                newName: "IX_Users_ListingId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Tags",
                newName: "ListingId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_RoomId",
                table: "Tags",
                newName: "IX_Tags_ListingId");

            migrationBuilder.CreateTable(
                name: "ItemOrders",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "integer", nullable: false),
                    OrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrders", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_ItemOrders_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsLeasable = table.Column<bool>(type: "boolean", nullable: false),
                    OrdersId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "Id", "ImageUrl", "IsLeasable", "OrdersId", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", true, null, 39.99m, "Room 1", 1 },
                    { 2, "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", true, null, 49.99m, "Room 2", 2 },
                    { 3, "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", false, null, 59.99m, "Room 3", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemListing_ListingsId",
                table: "ItemListing",
                column: "ListingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrdersId",
                table: "ItemOrders",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_OrdersId",
                table: "Listings",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Listings_ListingId",
                table: "Tags",
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
                name: "FK_Users_Orders_OrdersId",
                table: "Users",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
