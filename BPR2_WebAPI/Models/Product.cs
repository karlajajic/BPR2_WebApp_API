using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class Product
    {
        public long Id { get; set; }
        public long Barcode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }
        public string Brand { get; set;  }
    }
}
