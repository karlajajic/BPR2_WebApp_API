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
        private List<SoldProductModel> models = new List<SoldProductModel>();

        public IActionResult Index()
        {
            List<SoldProductDTO> dTOs = apiHelper.GetSoldProductsByDate(DateTime.Now).Result;
            List<ProductDTO> products = apiHelper.GetProducts().Result;

            dTOs.ForEach(p =>
            {
                var product = products.FirstOrDefault(product => p.ProductId == product.Id);
                if(product != null)
                {
                    var sp = new SoldProductModel() { Id = p.Id, Date = p.Date, ProductBarcode = product.Barcode, ProductName = product.Name, Quantity = p.Quantity, StoreName = p.StoreName };
                }
            });
            return View(models);
        }

        // GET: SoldProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SoldProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoldProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SoldProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SoldProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SoldProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SoldProducts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
