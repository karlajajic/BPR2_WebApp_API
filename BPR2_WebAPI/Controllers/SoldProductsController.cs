using BPR2_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPR2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public SoldProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{store}/{date}")]
        public ActionResult<IEnumerable<SoldProduct>> GetSoldProductsForStoreAndDate(string store, DateTime date)
        {
            return _context.SoldProducts.ToList().FindAll(p => p.Date.Date.Equals(date.Date) && p.StoreName.Equals(store));
        }

        [HttpGet("{date}")]
        public ActionResult<IEnumerable<SoldProduct>> GetSoldProductsForDate(DateTime date)
        {
            return _context.SoldProducts.ToList().FindAll(p => p.Date.Date.Equals(date.Date));
        }

        [Route("{store}/{productId}/{quantity}")]
        [HttpPost]
        public async Task<ActionResult<SoldProduct>> PostSoldProduct([FromRoute] string store, [FromRoute] long productId, [FromRoute] int quantity)
        {
            var exists = _context.SoldProducts.FirstOrDefault(p => p.ProductId == productId && p.Date.Date.Equals(DateTime.Now));
            if (exists != null)
            {
                exists.Quantity += quantity;
                _context.Entry(exists).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(exists);
            }

            var sold = new SoldProduct() { ProductId = productId, Date = DateTime.Now, Quantity = quantity, StoreName = store };
            _context.SoldProducts.Add(sold);
            await _context.SaveChangesAsync();

            return Ok(sold);
        }
    }
}
