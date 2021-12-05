using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class Store
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
    }
}
