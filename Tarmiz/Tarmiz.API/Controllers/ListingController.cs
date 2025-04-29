using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tarmiz.API.Data;
using Tarmiz.API.Models;
using Tarmiz.API.Models.DTO;
using Tarmiz.API.Repositories.Repository;

namespace Tarmiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly TarmizDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IListingRepository listingRepository;

        public ListingController(TarmizDbContext dbContext, IMapper mapper, IListingRepository listingRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.listingRepository = listingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lists =await listingRepository.GetAllAsync();
            return Ok(mapper.Map<List<ListingDTO>>(lists));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var list = await listingRepository.GetAsync(x => x.ListingId == id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ListingDTO>(list));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddListRequestDTO addListRequestDTO)
        {
            var listing = mapper.Map<Listing>(addListRequestDTO);
            await listingRepository.AddAsync(listing);
            return Ok(mapper.Map<ListingDTO>(listing));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateListRequestDTO updateListRequestDTO)
        {
            var existingListing = await listingRepository.GetAsync(x => x.ListingId == id);
            if (existingListing == null)
            {
                return NotFound();
            }
            mapper.Map(updateListRequestDTO, existingListing);
            await listingRepository.UpdateAsync(existingListing);
            return Ok(mapper.Map<ListingDTO>(existingListing));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var existingListing = await listingRepository.GetAsync(x => x.ListingId == id);
            if (existingListing == null)
            {
                return NotFound();
            }
            await listingRepository.RemoveAsync(existingListing);
            return Ok(mapper.Map<ListingDTO>(existingListing));
        }


    }
}
