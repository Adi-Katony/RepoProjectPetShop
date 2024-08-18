using System.ComponentModel.DataAnnotations;

namespace ProjectPetShop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 90, ErrorMessage = "Age must be between 0 and 90.")]
        public int Age { get; set; }

        public string? PictureName { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; } // Foreign key property

        // Navigation properties
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
