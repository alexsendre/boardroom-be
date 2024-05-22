namespace BoardRoom.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Total { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
