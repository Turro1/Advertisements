using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisements.Identity.Models
{
    public class AppUser :IdentityUser
    {
        public string FirstName { get; set; }
        public bool AdminEnabled { get; set; }
    }
}
