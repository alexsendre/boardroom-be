namespace BoardRoom.DTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHost { get; set; }
        public string Uid { get; set; }
    }
}
