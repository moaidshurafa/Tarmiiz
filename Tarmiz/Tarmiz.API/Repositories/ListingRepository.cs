using Tarmiz.API.Data;
using Tarmiz.API.Models;
using Tarmiz.API.Repositories.Repository;

namespace Tarmiz.API.Repositories
{
    public class ListingRepository : Repository<Listing>, IListingRepository
    {
        private readonly TarmizDbContext dbContext;

        public ListingRepository(TarmizDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Listing> UpdateAsync(Listing listing)
        {
            dbContext.Listings.Update(listing);
            await dbContext.SaveChangesAsync();
            return listing;
        }
    }
}
