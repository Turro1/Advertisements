using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.Domain
{
    public class Advertisement
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}