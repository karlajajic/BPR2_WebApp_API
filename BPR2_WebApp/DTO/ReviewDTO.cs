using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.DTO
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string StoreName { get; set; }
    }
}
