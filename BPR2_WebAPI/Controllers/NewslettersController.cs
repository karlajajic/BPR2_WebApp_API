using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPR2_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPR2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewslettersController : ControllerBase
    {
        private readonly DataContext _context;

        public NewslettersController (DataContext context)
        {
            _context = context;
        }

        // GET: api/<NewslettersController>
        [HttpGet]
        public ActionResult<List<Newsletter>> GetNewsletters()
        {
            return _context.Newsletters.AsEnumerable().ToList();
        }

        // GET api/<NewslettersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Newsletter>> GetNewsletter(int id)
        {
            var newsletter = await _context.Newsletters.FindAsync(id);

            if (newsletter == null)
            {
                return NotFound();
            }

            return newsletter;
        }

        // POST api/<NewslettersController>
        [HttpPost]
        public async Task<ActionResult<Newsletter>> PostNewsletter(Newsletter newsletter)
        {
            _context.Newsletters.Add(newsletter);
            await _context.SaveChangesAsync();

            var result = _context.Newsletters.FirstOrDefault(p => (p.Title == newsletter.Title && p.Details == newsletter.Details));
            return Ok(result);
        }

        // PUT api/<NewslettersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsletter(int id, Newsletter newsletter)
        {
            if (id != newsletter.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsletter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsletterExists(id))
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

        // DELETE api/<NewslettersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Newsletter>> Delete(int id)
        {
            var newsletter = await _context.Newsletters.FindAsync(id);
            if (newsletter == null)
            {
                return NotFound();
            }

            _context.Newsletters.Remove(newsletter);
            await _context.SaveChangesAsync();

            return newsletter;
        }

        private bool NewsletterExists(int id)
        {
            return _context.Newsletters.Any(e => e.Id == id);
        }

    }
}
