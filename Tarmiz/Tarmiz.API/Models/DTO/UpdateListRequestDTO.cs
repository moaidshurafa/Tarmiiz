using System.ComponentModel.DataAnnotations;

namespace Tarmiz.API.Models.DTO
{
    public class UpdateListRequestDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string NumberType { get; set; }
        [Required]
        public string Governorate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description has to be a maximum of 500 characters")]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
