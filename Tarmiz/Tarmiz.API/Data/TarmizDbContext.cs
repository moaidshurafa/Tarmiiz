using Microsoft.EntityFrameworkCore;
using Tarmiz.API.Models;

namespace Tarmiz.API.Data
{
    public class TarmizDbContext : DbContext
    {
        public TarmizDbContext(DbContextOptions<TarmizDbContext> options) : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; } // Example entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ListingId = Guid.Parse("aff847e9-a102-4353-9858-f4a6f1e04c24"),
                    Title = "Sample Listing",
                    NumberType = "Type Gold",
                    Governorate = "Irbid",
                    Price = 100.00m,
                    Description = "This is a sample listing.",
                    ImageUrl = "https://example.com/image.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

        }
    }
}


