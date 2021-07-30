using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}