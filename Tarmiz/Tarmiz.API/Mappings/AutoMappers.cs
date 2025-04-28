using AutoMapper;
using Tarmiz.API.Models;
using Tarmiz.API.Models.DTO;

namespace Tarmiz.API.Mappings
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Listing, ListingDTO>().ReverseMap();
            CreateMap<Listing, AddListRequestDTO>().ReverseMap();
            CreateMap<Listing, UpdateListRequestDTO>().ReverseMap();



        }
    }
}
