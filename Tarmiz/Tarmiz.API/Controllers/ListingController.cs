using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tarmiz.API.Data;
using Tarmiz.API.Models;
using Tarmiz.API.Models.DTO;

namespace Tarmiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly TarmizDbContext dbContext;
        private readonly IMapper mapper;

        public ListingController(TarmizDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lists =await dbContext.Listings.ToListAsync();
            return Ok(mapper.Map<List<ListingDTO>>(lists));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var list = await dbContext.Listings.FirstOrDefaultAsync(x => x.ListingId == id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ListingDTO>(list));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddListRequestDTO addListRequestDTO)
        {
            if (addListRequestDTO == null)
            {
                return BadRequest();
            }
            var listing = mapper.Map<Listing>(addListRequestDTO);
            listing.ListingId = Guid.NewGuid();
            await dbContext.Listings.AddAsync(listing);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = listing.ListingId }, mapper.Map<ListingDTO>(listing));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateListRequestDTO updateListRequestDTO)
        {
            if (updateListRequestDTO == null)
            {
                return BadRequest();
            }
            var listing = await dbContext.Listings.FirstOrDefaultAsync(x => x.ListingId == id);
            if (listing == null)
            {
                return NotFound();
            }
            mapper.Map(updateListRequestDTO, listing);
            dbContext.Listings.Update(listing);
            await dbContext.SaveChangesAsync();
            return Ok(mapper.Map<ListingDTO>(listing));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var listing = await dbContext.Listings.FirstOrDefaultAsync(x => x.ListingId == id);
            if (listing == null)
            {
                return NotFound();
            }
            dbContext.Listings.Remove(listing);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}
