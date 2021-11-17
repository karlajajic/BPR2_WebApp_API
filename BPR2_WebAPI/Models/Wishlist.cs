using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class Wishlist
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
