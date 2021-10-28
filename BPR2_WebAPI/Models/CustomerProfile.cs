using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class CustomerProfile
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string Username { get; set; }
    }
}
