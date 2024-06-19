namespace BoardRoom.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentTypeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Total { get; set; }
        public bool IsClosed { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public decimal? CalculateTotal
        {
            get
            {
                if (Items.Any())
                {
                    decimal? itemTotal = Items.Sum(item => item.Price);
                    return itemTotal;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
