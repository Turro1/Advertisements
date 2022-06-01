using System;
using FluentValidation;

namespace Advertisements.Application.Advertisements.Commands.UpdateAdvertisement
{
    public class UpdateAdvertisementCommandValidator : AbstractValidator<UpdateAdvertisementCommand>
    {
        public UpdateAdvertisementCommandValidator()
        {
            RuleFor(updateAdvertisementCommand =>
               updateAdvertisementCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateAdvertisementCommand =>
               updateAdvertisementCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateAdvertisementCommand =>
                updateAdvertisementCommand.Text).NotEmpty().MaximumLength(250);
        }
    }
}
