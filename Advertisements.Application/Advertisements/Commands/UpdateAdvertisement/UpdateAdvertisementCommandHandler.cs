using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Advertisements.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Advertisements.Application.Common.Exceptions;
using Advertisements.Domain;

namespace Advertisements.Application.Advertisements.Commands.UpdateAdvertisement
{
    public class UpdateNoteCommandHandler
           : IRequestHandler<UpdateAdvertisementCommand>
    {
        private readonly IAdvertisementsDbContext _dbContext;

        public UpdateNoteCommandHandler(IAdvertisementsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateAdvertisementCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Advertisements.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Advertisement), request.Id);
            }

            entity.Text = request.Text;
            entity.Image = request.Image;
            entity.Created = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}