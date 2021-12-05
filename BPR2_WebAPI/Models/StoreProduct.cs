using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class StoreProduct
    {
        public long Id { get; set; }
        public long StoreId { get; set; }
        public long ProductId { get; set; }
    }
}
