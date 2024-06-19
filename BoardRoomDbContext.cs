using Microsoft.EntityFrameworkCore;
using BoardRoom.Models;

namespace BoardRoom
{
    public class BoardRoomDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public BoardRoomDbContext(DbContextOptions<BoardRoomDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Username = "jordancarter", FirstName = "Jordan", LastName = "Carter", Email = "jordancarter@test.com", ImageUrl = "https://cdns-images.dzcdn.net/images/artist/16cc4a271b96586a46c35d8182412e92/1900x1900-000000-80-0-0.jpg", Bio = "hello! my bio", IsSeller = false, Uid = "uid1" },
                new User { Id = 2, Username = "testcase", FirstName = "Austin", LastName = "Post", Email = "postmalone@gmail.com", ImageUrl = "https://m.media-amazon.com/images/M/MV5BODg4N2I0NmEtNTIyMS00MzVjLThjYzgtODAwMzcwYThkMTVkXkEyXkFqcGdeQXVyMTI2Nzk3NzI4._V1_FMjpg_UX1000_.jpg", Bio = "hello! my bio", IsSeller = false, Uid = "uid1" },
                new User { Id = 3, Username = "fishtank", FirstName = "Jen", LastName = "Jones", Email = "jenjo@gmail.com", ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/1189837141/2019-American-Music-Awards---Red-Carpet/960x0.jpg?format=jpg&width=960", Bio = "hello! my bio", IsSeller = false, Uid = "uid1" },
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { Id = 1, PaymentTypeId = 1, UserId = 1, Address = "3939 Coco Mel", City = "Candy", State = "AK", IsClosed = true, Total = 0, },
                new Order { Id = 2, PaymentTypeId = 2, UserId = 2, Address = "333 Angel Ln", City = "Brite", State = "TX", IsClosed = true, Total = 0 },
                new Order { Id = 3, PaymentTypeId = 3, UserId = 3, Address = "1 W North St", City = "Harara", State = "CA", IsClosed = false, Total = 0 },
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item { Id = 1, Name = "Monitor", Price = 159.99M, RoomId = 1, SellerId = 1, ImageUrl = "https://i.pcmag.com/imagery/reviews/05mQGIDQOTCx8qyj5vd3S8t-1.fit_lim.size_840x473.v1695825614.jpg" },
                new Item { Id = 2, Name = "Deskpad", Price = 19.99M, RoomId = 2, SellerId = 2, ImageUrl = "https://images.stockx.com/images/FaZe-x-Murakami-Mousepad-Black.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1637778655" },
                new Item { Id = 3, Name = "Couch", Price = 349.99M, RoomId = 3, SellerId = 3, ImageUrl = "https://m.media-amazon.com/images/I/81Y5x1jljBL._AC_UF1000,1000_QL80_.jpg" },
            });

            modelBuilder.Entity<Room>().HasData(new Room[]
            {
                new Room { Id = 1, Title = "Room 1", ImageUrl = "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", Description = "this is a nice description for room 1!", Location = "Lexington, KY", SellerId = 1 },
                new Room { Id = 2, Title = "Room 2", ImageUrl = "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", Description = "this is a nice description for room 2!", Location = "Nashville, TN", SellerId = 2 },
                new Room { Id = 3, Title = "Room 3", ImageUrl = "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", Description = "this is a nice description for room 3!", Location = "Houston, TX", SellerId = 3 },
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType { Id = 1, Label = "Debit/Credit Card" },
                new PaymentType { Id = 2, Label = "Cash" },
                new PaymentType { Id = 3, Label = "PayPal" },
                new PaymentType { Id = 4, Label = "Klarna" }
            });

            modelBuilder.Entity<Tag>().HasData(new Tag[]
            {
                new Tag { Id = 1, Label = "Gaming" },
                new Tag { Id = 2, Label = "Minimalist" },
                new Tag { Id = 3, Label = "Workspace" },
                new Tag { Id = 4, Label = "Quirky" },
            });
        }
    }
}
