using System;
using FluentValidation;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementList
{
    public class GetAdvertisementListQueryValidator : AbstractValidator<GetAdvertisementListQuery>
    {
        public GetAdvertisementListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
