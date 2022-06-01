using AutoMapper;
using System;
using Advertisements.Application.Common.Mappings;
using Advertisements.Application.Advertisements.Commands.UpdateAdvertisement;

namespace Advertisement.WebApi.Models
{
    public class UpdateAdvertisementDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAdvertisementDto, UpdateAdvertisementCommand>()
                .ForMember(advertisementCommand => advertisementCommand.Id,
                    opt => opt.MapFrom(advertisementDto => advertisementDto.Id))
                .ForMember(advertisementCommand => advertisementCommand.Text,
                    opt => opt.MapFrom(advertisementDto => advertisementDto.Text))
                .ForMember(advertisementCommand => advertisementCommand.Image,
                    opt => opt.MapFrom(advertisementDto => advertisementDto.Image));
        }
    }
}
