using Microsoft.EntityFrameworkCore;
using BoardRoom.Models;

namespace BoardRoom
{
    public class BoardRoomDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }
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
                new User { Id = 1, Username = "jordancarter", ImageUrl = "https://cdns-images.dzcdn.net/images/artist/16cc4a271b96586a46c35d8182412e92/1900x1900-000000-80-0-0.jpg", IsHost = false, Uid = "uid1" },
                new User { Id = 2, Username = "testcase", ImageUrl = "https://m.media-amazon.com/images/M/MV5BODg4N2I0NmEtNTIyMS00MzVjLThjYzgtODAwMzcwYThkMTVkXkEyXkFqcGdeQXVyMTI2Nzk3NzI4._V1_FMjpg_UX1000_.jpg", IsHost = false, Uid = "uid1" },
                new User { Id = 3, Username = "fishtank", ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/1189837141/2019-American-Music-Awards---Red-Carpet/960x0.jpg?format=jpg&width=960", IsHost = false, Uid = "uid1" },
            });

            modelBuilder.Entity<Listing>().HasData(new Listing[]
            {
                new Listing { Id = 1, FirstName = "Jordan", LastName = "Carter", Email = "jordancarter@test.com", PaymentTypeId = 1, Total = 30.00M, RoomId = 1, UserId = 1 },
                new Listing { Id = 2, FirstName = "Austin", LastName = "Post", Email = "postmalone@gmail.com", PaymentTypeId = 2, RoomId = 3, UserId = 2, Total = 489.38M },
                new Listing { Id = 3, FirstName = "Jen", LastName = "Jones", Email = "jenjo@gmail.com", PaymentTypeId = 3, RoomId = 2, UserId = 3, Total = 89.83M },
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item { Id = 1, Name = "Monitor", Price = 159.99M, ImageUrl = "https://i.pcmag.com/imagery/reviews/05mQGIDQOTCx8qyj5vd3S8t-1.fit_lim.size_840x473.v1695825614.jpg", RoomId = 1 },
                new Item { Id = 2, Name = "Deskpad", Price = 19.99M, ImageUrl = "https://images.stockx.com/images/FaZe-x-Murakami-Mousepad-Black.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1637778655", RoomId = 2 },
                new Item { Id = 3, Name = "Couch", Price = 349.99M, ImageUrl = "https://m.media-amazon.com/images/I/81Y5x1jljBL._AC_UF1000,1000_QL80_.jpg", RoomId = 3 },
            });

            modelBuilder.Entity<Room>().HasData(new Room[]
            {
                new Room { Id = 1, Title = "Room 1", Price = 39.99M, ImageUrl = "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg", UserId = 1, IsLeasable = true },
                new Room { Id = 2, Title = "Room 2", Price = 49.99M, ImageUrl = "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg", UserId = 2, IsLeasable = true },
                new Room { Id = 3, Title = "Room 3", Price = 59.99M, ImageUrl = "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg", UserId = 3, IsLeasable = false },
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
