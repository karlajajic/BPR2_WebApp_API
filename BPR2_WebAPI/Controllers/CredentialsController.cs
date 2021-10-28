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
    public class CredentialsController : ControllerBase
    {
        private readonly DataContext _context;

        public CredentialsController(DataContext context)
        {
            _context = context;
        }

        // use to authenticate employees
        // GET api/<CredentialsController>/auth/5
        [Route("/auth/{code}")]
        [HttpGet]
        public ActionResult<long> Authenticate([FromRoute] long code)
        {
            var credentials = _context.Credentials.FirstOrDefault(p => p.Code == code);

            if (credentials == null)
            {
                return NotFound();
            }

            if (credentials.IsEmployee)
            {
                return credentials.Id;
            }

            return -1;
        }

        // use to authenticate customers
        // GET api/<CredentialsController>/log/5
        [Route("/log/{code}")]
        [HttpGet]
        public ActionResult<long> Log([FromRoute] long code)
        {
            var credentials = _context.Credentials.FirstOrDefault(p => p.Code == code);

            if (credentials == null)
            {
                return NotFound();
            }

            if (!credentials.IsEmployee)
            {
                return credentials.Id;
            }

            return -1;
        }

        // POST api/<CredentialsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Credentials credentials)
        {
            if (credentials.IsEmployee)
            {
                return BadRequest(); //only customer profiles should be added through API
            }

            var existing = _context.Credentials.FirstOrDefault(p => p.Code == credentials.Code);

            if (existing == null)
            {
                _context.Credentials.Add(credentials);
                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
