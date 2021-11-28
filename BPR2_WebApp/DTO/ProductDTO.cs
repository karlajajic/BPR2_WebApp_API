using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public long Barcode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
    }
}
