using System;
using FluentValidation;

namespace Advertisements.Application.Advertisements.Commands.CreateAdvertisement
{
    public class CreateAdvertisementCommandValidator : AbstractValidator<CreateAdvertisementCommand>
    {
        public CreateAdvertisementCommandValidator()
        {
            RuleFor(createAdvertisementCommand =>
                createAdvertisementCommand.Text).NotEmpty().MaximumLength(250);
            RuleFor(createAdvertisementCommand =>
            createAdvertisementCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
