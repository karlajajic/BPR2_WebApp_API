using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.DTO
{
    public class SoldProductDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string StoreName { get; set; }
    }
}
