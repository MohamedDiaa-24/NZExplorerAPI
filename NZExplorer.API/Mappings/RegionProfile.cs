using AutoMapper;
using NZExplorer.API.Dtos;
using NZExplorer.API.Models;

namespace NZExplorer.API.Mappings
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<GetRegion, Region>().ReverseMap();
            CreateMap<AddRegionRequest, Region>().ReverseMap();
            CreateMap<UpdateRegionRequest, Region>().ReverseMap();
        }
    }
}
