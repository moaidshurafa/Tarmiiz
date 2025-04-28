namespace Tarmiz.API.Models
{
    public class Listing
    {
        public Guid ListingId { get; set; }
        public string Title { get; set; }
        public string NumberType { get; set; }
        public string Governorate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
