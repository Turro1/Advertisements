using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Advertisements.Domain;
using Advertisements.Application.Interfaces;
using System.Threading;

namespace Advertisements.Application.Advertisements.Commands.CreateAdvertisement
{
    public class CreateAdvertisementCommandHandler
        : IRequestHandler<CreateAdvertisementCommand, Guid>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        public CreateAdvertisementCommandHandler(IAdvertisementsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateAdvertisementCommand request,
           CancellationToken cancellationToken)
        {
            Random random = new Random();
            var advertisement = new Advertisement
            {
                UserId = request.UserId,
                Number = request.Number,
                Text = request.Text,
                Rating = random.Next(1, 5),
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Image = request.Image
            };

            await _dbContext.Advertisements.AddAsync(advertisement, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return advertisement.Id;
        }
    }
}
