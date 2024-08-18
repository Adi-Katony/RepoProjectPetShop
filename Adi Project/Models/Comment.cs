using System.ComponentModel.DataAnnotations;

namespace ProjectPetShop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; } // Foreign key property

        [StringLength(70, ErrorMessage = "Comment cannot exceed 70 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Comment can only contain letters and numbers.")]
        public string? Review { get; set; } // Renamed for clarity

        // Navigation property
        public virtual Animal? Animal { get; set; }
    }
}
