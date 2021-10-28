using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class Credentials
    {
        public long Id { get; set; }
        public long Code { get; set; } //encrypted
        public bool IsEmployee { get; set; }
    }
}
