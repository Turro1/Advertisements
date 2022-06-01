using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Advertisements.Application.Advertisements.Commands.CreateAdvertisement
{
    public class CreateAdvertisementCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int Number { get; set; }
        public string Image { get; set; }
    }
}
