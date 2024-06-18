using System.ComponentModel.DataAnnotations;

namespace BoardRoom.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsSeller { get; set; }
        public string? Uid { get; set; }
    }
}
