using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Models
{
    public class SoldProductsModel
    {
        public DateTime Date { get; set; }
        public List<SoldProductModel> Products { get; set; }
    }
}
