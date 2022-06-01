using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advertisements.Domain;

namespace Advertisements.Application.Interfaces
{
    public interface IAdvertisementsDbContext
    {
        DbSet<Advertisement> Advertisements { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
