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
            var page = request.Page;
            int pageSize = 4;
            List<AdvertisementLookupDto> advertisementsQuery = null;

            if (request.Number != null)
            {
                advertisementsQuery = await _dbContext.Advertisements
                    .Where(advertisement => advertisement.UserId == request.UserId 
                    && advertisement.Number == request.Number)
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<AdvertisementLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }

            else if (!String.IsNullOrEmpty(request.Text))
            {
                advertisementsQuery = await _dbContext.Advertisements
                    .Where(advertisement => advertisement.UserId == request.UserId 
                    && advertisement.Text.ToUpper().Contains(request.Text.ToUpper()))
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<AdvertisementLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }

            else if (request.Number == null && request.Text == null)
            {
                advertisementsQuery = await _dbContext.Advertisements
                    .Where(advertisement => advertisement.UserId == request.UserId)
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<AdvertisementLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }

            return new AdvertisementListVm { Advertisements = advertisementsQuery };
        }
    }
}
