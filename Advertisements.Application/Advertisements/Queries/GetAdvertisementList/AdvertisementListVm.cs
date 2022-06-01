using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.Application.Advertisements.Queries.GetAdvertisementList
{
    public class AdvertisementListVm
    {
        public IList<AdvertisementLookupDto> Advertisements { get; set; }
    }
}
