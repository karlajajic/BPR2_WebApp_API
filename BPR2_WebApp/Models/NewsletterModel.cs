using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Models
{
    public class NewsletterModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        [Display(Name = "Valid from")]
        public DateTime ValidFrom { get; set; }
        [Display(Name = "Valid until")]
        public DateTime ValidTo { get; set; }
    }
}
