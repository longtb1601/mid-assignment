using System;
using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Models.DTO
{
    public class BorrowingRequestDTO
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int LibrarianId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }
    
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}