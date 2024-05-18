using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoardRoom.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
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
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IsLeasable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsHost = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "RoomId" },
                values: new object[,]
                {
                    { 1, "https://i.pcmag.com/imagery/reviews/05mQGIDQOTCx8qyj5vd3S8t-1.fit_lim.size_840x473.v1695825614.jpg", "Monitor", 159.99m, 1 },
                    { 2, "https://images.stockx.com/images/FaZe-x-Murakami-Mousepad-Black.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1637778655", "Deskpad", 19.99m, 2 },
                    { 3, "https://m.media-amazon.com/images/I/81Y5x1jljBL._AC_UF1000,1000_QL80_.jpg", "Couch", 349.99m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PaymentTypeId", "RoomId", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, "jordancarter@test.com", "Jordan", "Carter", 1, 1, 30.00m, 1 },
                    { 2, "postmalone@gmail.com", "Austin", "Post", 2, 3, 489.38m, 2 },
                    { 3, "jenjo@gmail.com", "Jen", "Jones", 3, 2, 89.83m, 3 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Debit/Credit Card" },
                    { 2, "Cash" },
                    { 3, "PayPal" },
                    { 4, "Klarna" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageUrl", "IsLeasable", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", true, 39.99m, "Room 1", 1 },
                    { 2, "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", true, 49.99m, "Room 2", 2 },
                    { 3, "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", false, 59.99m, "Room 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Gaming" },
                    { 2, "Minimalist" },
                    { 3, "Workspace" },
                    { 4, "Quirky" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ImageUrl", "IsHost", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "https://cdns-images.dzcdn.net/images/artist/16cc4a271b96586a46c35d8182412e92/1900x1900-000000-80-0-0.jpg", false, "uid1", "jordancarter" },
                    { 2, "https://m.media-amazon.com/images/M/MV5BODg4N2I0NmEtNTIyMS00MzVjLThjYzgtODAwMzcwYThkMTVkXkEyXkFqcGdeQXVyMTI2Nzk3NzI4._V1_FMjpg_UX1000_.jpg", false, "uid1", "testcase" },
                    { 3, "https://imageio.forbes.com/specials-images/imageserve/1189837141/2019-American-Music-Awards---Red-Carpet/960x0.jpg?format=jpg&width=960", false, "uid1", "fishtank" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
