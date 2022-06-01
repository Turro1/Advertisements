using Advertisements.Application.Common.Mappings;
using Advertisements.Application.Advertisements.Commands.CreateAdvertisement;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Advertisement.WebApi.Models
{
    public class CreateAdvertisementDto : IMapWith<CreateAdvertisementCommand>
    {
        [Required]
        public string Text { get; set; }
        public string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdvertisementDto, CreateAdvertisementCommand>()
                .ForMember(advertisementCommand => advertisementCommand.Text,
                opt => opt.MapFrom(advertisementDto => advertisementDto.Text))
                .ForMember(advertisementCommand => advertisementCommand.Image,
                opt => opt.MapFrom(advertisementDto => advertisementDto.Image));
        }
    }
}
