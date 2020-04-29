using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace API.Controllers.DB.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatedistribController : ControllerBase
    {
        private readonly LocalContext _context;

        public RatedistribController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Ratedistrib
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateDistrib>>> GetRatedistrib()
        {
            return await _context.RateDistrib.ToListAsync();
        }

        // GET: api/Ratedistrib/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateDistrib>> GetRatedistrib(long id)
        {
            var ratedistrib = await _context.RateDistrib.FindAsync(id);

            if (ratedistrib == null)
            {
                return NotFound();
            }

            return ratedistrib;
        }

        // PUT: api/Ratedistrib/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatedistrib(long id, RateDistrib ratedistrib)
        {
            if (id != ratedistrib.Id)
            {
                return BadRequest();
            }

            _context.Entry(ratedistrib).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatedistribExists(id))
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

        // POST: api/Ratedistrib
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RateDistrib>> PostRatedistrib(RateDistrib ratedistrib)
        {
            _context.RateDistrib.Add(ratedistrib);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatedistrib", new { id = ratedistrib.Id }, ratedistrib);
        }

        // DELETE: api/Ratedistrib/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RateDistrib>> DeleteRatedistrib(long id)
        {
            var ratedistrib = await _context.RateDistrib.FindAsync(id);
            if (ratedistrib == null)
            {
                return NotFound();
            }

            _context.RateDistrib.Remove(ratedistrib);
            await _context.SaveChangesAsync();

            return ratedistrib;
        }

        private bool RatedistribExists(long id)
        {
            return _context.RateDistrib.Any(e => e.Id == id);
        }
    }
}
