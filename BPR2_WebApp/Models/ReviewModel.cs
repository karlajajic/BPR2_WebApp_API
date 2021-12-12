using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Models
{
    public class ReviewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        [Display(Name = "Store")]
        public string StoreName { get; set; }
    }
}
