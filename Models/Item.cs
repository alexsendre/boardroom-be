namespace BoardRoom.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
