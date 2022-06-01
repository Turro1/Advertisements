using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Advertisements.Domain;
using Advertisements.Application.Interfaces;
using Advertisements.Application.Common.Exceptions;

namespace Advertisements.Application.Advertisements.Commands.DeleteCommand
{
    public class DeleteAdvertisementCommandHandler
        : IRequestHandler<DeleteAdvertisementCommand>
    {
        private readonly IAdvertisementsDbContext _dbContext;

        public DeleteAdvertisementCommandHandler(IAdvertisementsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteAdvertisementCommand request,
           CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Advertisements
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Advertisement), request.Id);
            }

            _dbContext.Advertisements.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
