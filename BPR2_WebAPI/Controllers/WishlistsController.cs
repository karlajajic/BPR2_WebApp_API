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
    public class WishlistsController : ControllerBase
    {
        private readonly DataContext _context;

        public WishlistsController(DataContext context)
        {
            _context = context;
        }

        // GET api/<WhishlistsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(long id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        // GET api/<WhishlistsController>/5
        [Route("/customerWishLists/{customerId}")]
        [HttpGet]
        public ActionResult<List<Wishlist>> GetCustomerWishlists([FromRoute] long customerId)
        {
            var wishlist = _context.Wishlists.AsEnumerable().Where(p => p.ProfileId == customerId).ToList();

            if (wishlist == null)
            {
                return new List<Wishlist>();
            }

            return wishlist;
        }

        // GET api/<WhishlistsController>/5
        [Route("/wishListProducts/{wishListId}/")]
        [HttpGet]
        public ActionResult<List<Product>> GetWishlistProducts([FromRoute] long wishListId)
        {
            var wproducts = _context.WishlistProducts.AsEnumerable().Where(p => p.WishlistId == wishListId).ToList();

            if (wproducts == null)
            {
                return new List<Product>();
            }

            var products = new List<Product>();
            wproducts.ForEach(wp =>
            {
               var product = _context.Products.AsEnumerable().FirstOrDefault(p => p.Id == wp.ProductId);
               if (product != null)
                   products.Add(product);
            });

            return products;
        }

        // POST api/<WhishlistsController>
        [Route("/wishListProducts/{wishListId}/{productId}")]
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlistProduct([FromRoute] long wishListId, [FromRoute] long productId)
        {
            var isThere = _context.WishlistProducts.AsEnumerable().FirstOrDefault(wp => (wp.ProductId == productId && wp.WishlistId == wishListId));
            if (isThere != null)
                return Ok();

            _context.WishlistProducts.Add(new WishlistProducts { ProductId = productId, WishlistId = wishListId });
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<WhishlistsController>/5
        [Route("/wishListProducts/{wishListId}/{productId}")]
        [HttpDelete]
        public async Task<ActionResult<WishlistProducts>> DeleteWishlist([FromRoute] long wishListId, [FromRoute] long productId)
        {
            var wishlistProduct = _context.WishlistProducts.AsEnumerable().FirstOrDefault(p => (p.WishlistId == wishListId && p.ProductId == productId));
            if (wishlistProduct == null)
            {
                return NotFound();
            }

            _context.WishlistProducts.Remove(wishlistProduct);
            await _context.SaveChangesAsync();

            return wishlistProduct;
        }

        // POST api/<WhishlistsController>
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }

        // PUT api/<WhishlistsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(long id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<WhishlistsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wishlist>> DeleteWishlist(long id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return wishlist;
        }

        private bool WishlistExists(long id)
        {
            return _context.Wishlists.Any(e => e.Id == id);
        }
    }
}
