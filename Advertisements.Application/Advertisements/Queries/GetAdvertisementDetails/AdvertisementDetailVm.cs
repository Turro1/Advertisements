using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.Application.Common.Mappings;
using Advertisements.Domain;
using AutoMapper;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementDetails
{
    public class AdvertisementDetailVm : IMapWith<Advertisement>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public DateTime ExpirationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Advertisement, AdvertisementDetailVm>()
                .ForMember(advertisementVm => advertisementVm.Text,
                opt => opt.MapFrom(advertisement => advertisement.Text))
                .ForMember(advertisementVm => advertisementVm.Image,
                opt => opt.MapFrom(advertisement => advertisement.Image))
                .ForMember(advertisementVm => advertisementVm.Id,
                opt => opt.MapFrom(advertisement => advertisement.Id))
                .ForMember(advertisementVm => advertisementVm.Number,
                opt => opt.MapFrom(advertisement => advertisement.Number))
                .ForMember(advertisementVm => advertisementVm.Rating,
                opt => opt.MapFrom(advertisement => advertisement.Rating))
                .ForMember(advertisementVm => advertisementVm.Created,
                opt => opt.MapFrom(advertisement => advertisement.Created))
                .ForMember(advertisementVm => advertisementVm.ExpirationDate,
                opt => opt.MapFrom(advertisement => advertisement.ExpirationDate));
        }
    }
}
