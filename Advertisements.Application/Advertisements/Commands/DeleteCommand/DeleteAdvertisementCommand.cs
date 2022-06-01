using System;
using MediatR;

namespace Advertisements.Application.Advertisements.Commands.DeleteCommand
{
    public class DeleteAdvertisementCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
