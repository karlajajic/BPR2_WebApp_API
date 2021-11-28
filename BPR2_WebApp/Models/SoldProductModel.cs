using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Models
{
    public class SoldProductModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long ProductBarcode { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string StoreName { get; set; }
    }
}
