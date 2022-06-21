using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.Application.Common.Mappings;
using Advertisements.Domain;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementList
{
    public class AdvertisementLookupDto : IMapWith<Advertisement>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Number { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<Advertisement, AdvertisementLookupDto>()
                .ForMember(advertisementDto => advertisementDto.Id,
                opt => opt.MapFrom(advertisement => advertisement.Id))
                .ForMember(advertisementDto => advertisementDto.Text,
                opt => opt.MapFrom(advertisement => advertisement.Text))
                .ForMember(advertisementDto => advertisementDto.Image,
                opt => opt.MapFrom(advertisement => advertisement.Image))
                .ForMember(advertisementDto => advertisementDto.Number,
                opt => opt.MapFrom(advertisement => advertisement.Number)); ;

        }
    }
}
