using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class WishlistProduct
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long WishlistId { get; set; }
    }
}
