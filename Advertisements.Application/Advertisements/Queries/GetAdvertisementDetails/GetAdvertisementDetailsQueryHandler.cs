using System.Threading.Tasks;
using System.Threading;
using MediatR;
using AutoMapper;
using Advertisements.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Advertisements.Application.Common.Exceptions;
using Advertisements.Domain;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementDetails
{
    public class GetUserDetailsQueryHandler 
        :IRequestHandler<GetAdvertisementDetailsQuery, AdvertisementDetailVm>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<AdvertisementDetailVm> Handle(GetAdvertisementDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Advertisements
               .FirstOrDefaultAsync(advertisement =>
               advertisement.Id == request.Id, cancellationToken); 
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Advertisement), request.Id);
            }
            return _mapper.Map<AdvertisementDetailVm>(entity);
        }
    }
}
