using System;
using FluentValidation;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementDetails
{
    public class GetAdvertisementDetailsQueryValidator : AbstractValidator<GetAdvertisementDetailsQuery>
    {
        public GetAdvertisementDetailsQueryValidator()
        {
            RuleFor(advertisement => advertisement.UserId).NotEqual(Guid.Empty);
            RuleFor(advertisement => advertisement.Id).NotEqual(Guid.Empty);
        }
    }
}
