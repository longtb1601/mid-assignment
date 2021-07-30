using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}