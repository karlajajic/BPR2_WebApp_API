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
    public class ReviewsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReviewsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public ActionResult<List<Review>> GetReviews()
        {
            var reviews = _context.Reviews.ToList();

            if (reviews == null)
            {
                return NotFound();
            }

            return reviews;
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public async Task<ActionResult<Review>> Post(Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok(review);
        }
    }
}
