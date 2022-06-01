using System;
using MediatR;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementDetails
{
    public class GetAdvertisementDetailsQuery : IRequest<AdvertisementDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
