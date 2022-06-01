using System;
using FluentValidation;

namespace Advertisements.Application.Advertisements.Commands.DeleteCommand
{
    public class DeleteAdvertisementCommandValidator : AbstractValidator<DeleteAdvertisementCommand>
    {
        public DeleteAdvertisementCommandValidator()
        {
            RuleFor(deleteAdvertisementCommand =>
               deleteAdvertisementCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteAdvertisementCommand =>
               deleteAdvertisementCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
