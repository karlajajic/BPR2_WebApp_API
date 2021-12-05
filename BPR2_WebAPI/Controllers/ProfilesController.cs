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
    public class ProfilesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfilesController(DataContext context)
        {
            _context = context;
        }

        // GET api/<ProfilesController>/log/5
        [Route("log/{code}")]
        [HttpGet]
        public ActionResult<CustomerProfile> GetProfileByCode([FromRoute] long code)
        {
            var credentials = _context.Credentials.AsEnumerable().FirstOrDefault(p => p.Code == code);

            if (credentials != null)
            {
                var profile = _context.CustomerProfiles.FirstOrDefault(p => p.ProfileId.Equals(credentials.Id));
                if (profile != null)
                {
                    return profile;
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        // GET api/<ProfilesController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerProfile> GetProfile(string id)
        {
            var profile = _context.CustomerProfiles.FirstOrDefault(p => p.ProfileId.Equals(id));
            if (profile != null)
            {
                return profile;
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProfilesController>
        [HttpPost]
        public async Task<ActionResult> PostCustomerProfile(CustomerProfile profile)
        {
            if (ProfileExists(profile.Id))
            {
                return BadRequest();
            }
            else
            {
                _context.CustomerProfiles.Add(profile);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        // PUT api/<ProfilesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(long id, [FromBody] CustomerProfile profile)
        {
            if (!id.Equals(profile.Id))
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(profile.Id))
                {
                    return NotFound();
                }
                else
                {
                    return Problem();
                }
            }

            return NoContent();
        }

        // DELETE api/<ProfilesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerProfile>> Delete(long id)
        {
            var profile = await _context.CustomerProfiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            _context.CustomerProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        private bool ProfileExists(long id)
        {
            return _context.CustomerProfiles.Any(e => e.Id == id);
        }
    }
}
