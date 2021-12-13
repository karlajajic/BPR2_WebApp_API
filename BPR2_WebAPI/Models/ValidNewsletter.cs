using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class ValidNewsletter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Interval { get; set; }
    }
}
