using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Models
{
    public class ReviewsModel
    {
        public string StoreName { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
