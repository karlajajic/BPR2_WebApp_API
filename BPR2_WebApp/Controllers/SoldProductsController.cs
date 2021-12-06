using BPR2_WebApp.DTO;
using BPR2_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Controllers
{
    public class SoldProductsController : Controller
    {
        private ApiHelper apiHelper = new ApiHelper();
        
        [HttpPost]
        public ActionResult Load(IFormCollection collection)
        {
            var d = DateTime.Parse(collection["Date"].ToString());
            if (d == null)
            {
                d = DateTime.Now;
            }

            List<SoldProductDTO> dTOs = apiHelper.GetSoldProductsByDate(d).Result;
            List<ProductDTO> products = apiHelper.GetProducts().Result;

            var models = new List<SoldProductModel>();

            dTOs.ForEach(p =>
            {
                var product = products.FirstOrDefault(product => p.ProductId == product.Id);
                if (product != null)
                {
                    var sp = new SoldProductModel() { Id = p.Id, Date = p.Date, ProductBarcode = product.Barcode, ProductName = product.Name, Quantity = p.Quantity, StoreName = p.StoreName };
                    models.Add(sp);
                }
            });

            var model = new SoldProductsModel() { Date = d, Products = models };
            return View("Index", model);
        }

        public IActionResult Index()
        {
            var d = DateTime.Now;

            List<SoldProductDTO> dTOs = apiHelper.GetSoldProductsByDate(d).Result;
            List<ProductDTO> products = apiHelper.GetProducts().Result;

            var models = new List<SoldProductModel>();

            dTOs.ForEach(p =>
            {
                var product = products.FirstOrDefault(product => p.ProductId == product.Id);
                if (product != null)
                {
                    var sp = new SoldProductModel() { Id = p.Id, Date = p.Date, ProductBarcode = product.Barcode, ProductName = product.Name, Quantity = p.Quantity, StoreName = p.StoreName };
                    models.Add(sp);
                }
            });

            var model = new SoldProductsModel() { Date = d, Products = models };
            return View("Index", model);
        }
    }
}
