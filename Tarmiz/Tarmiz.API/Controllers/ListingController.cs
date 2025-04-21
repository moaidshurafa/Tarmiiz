using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarmiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetListings()
        {
            // Simulate fetching listings from a database or service
            var listings = new List<string>
            {
                "Listing 1",
                "Listing 2",
                "Listing 3"
            };
            return Ok(listings);
        }
        [HttpGet("{id}")]
        public IActionResult GetListingById(int id)
        {
            // Simulate fetching a single listing by ID
            var listing = $"Listing {id}";
            if (listing == null)
            {
                return NotFound();
            }
            return Ok(listing);
        }
    }
}
