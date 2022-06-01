using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementList
{
    public class GetAdvertisementListQuery : IRequest<AdvertisementListVm>
    {
        public Guid UserId { get; set; }
    }
}
