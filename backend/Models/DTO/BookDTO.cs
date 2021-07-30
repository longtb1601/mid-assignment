using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Models.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}