using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AdvertisementsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
