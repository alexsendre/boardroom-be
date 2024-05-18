namespace BoardRoom.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Total { get; set; }
    }
}
