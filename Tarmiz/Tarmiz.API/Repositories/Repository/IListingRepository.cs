using Tarmiz.API.Models;

namespace Tarmiz.API.Repositories.Repository
{
    public interface IListingRepository : IRepository<Listing>
    {
        Task<Listing> UpdateAsync(Listing listing);
    }
}
