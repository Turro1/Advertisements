using System;
using MediatR;

namespace Advertisements.Application.Advertisements.Commands.UpdateAdvertisement
{
    public class UpdateAdvertisementCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
    }
}
