using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Advertisements.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementList
{
    public class GetAdvertisementListQueryHandler
        : IRequestHandler<GetAdvertisementListQuery, AdvertisementListVm>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAdvertisementListQueryHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper) => (_dbContext,_mapper) = (dbContext, mapper);

        public async Task<AdvertisementListVm> Handle(GetAdvertisementListQuery request,
            CancellationToken cancellationToken)
        {
            var advertisementsQuery = await _dbContext.Advertisements
                .Where(advertisement => advertisement.UserId == request.UserId)
                .ProjectTo<AdvertisementLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AdvertisementListVm { Advertisements = advertisementsQuery };
        }
    }
}
