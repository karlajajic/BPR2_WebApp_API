using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.DTO
{
    public class NewsletterDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
