using BPR2_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPR2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly DataContext _context;

        public StoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public ActionResult<List<Store>> GetStores()
        {
            return _context.Stores.AsEnumerable().ToList();
        }

        // GET api/<StoresController>/5
        [Route("/storeProducts/{storeId}")]
        [HttpGet]
        public ActionResult<List<Product>> GetStoreProducts([FromRoute] long storeId)
        {
            List<Product> products = new List<Product>();

            var storeProducts = _context.StoreProducts.AsEnumerable().Where(p => p.StoreId.Equals(storeId)).ToList();
            storeProducts.ForEach(sp =>
            {
                var p = _context.Products.FirstOrDefault(product => product.Id == sp.ProductId);
                if (p != null)
                {
                    products.Add(p);
                }
            });

            return products;
        }
    }
}
