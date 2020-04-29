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
    public class RatebuildupController : ControllerBase
    {
        private readonly LocalContext _context;

        public RatebuildupController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Ratebuildup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateBuildUp>>> GetRatebuildup()
        {
            return await _context.RateBuildUp.ToListAsync();
        }

        // GET: api/Ratebuildup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateBuildUp>> GetRatebuildup(long id)
        {
            var ratebuildup = await _context.RateBuildUp.FindAsync(id);

            if (ratebuildup == null)
            {
                return NotFound();
            }

            return ratebuildup;
        }

        // PUT: api/Ratebuildup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatebuildup(long id, RateBuildUp ratebuildup)
        {
            if (id != ratebuildup.Id)
            {
                return BadRequest();
            }

            _context.Entry(ratebuildup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatebuildupExists(id))
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

        // POST: api/Ratebuildup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RateBuildUp>> PostRatebuildup(RateBuildUp ratebuildup)
        {
            _context.RateBuildUp.Add(ratebuildup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatebuildup", new { id = ratebuildup.Id }, ratebuildup);
        }

        // DELETE: api/Ratebuildup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RateBuildUp>> DeleteRatebuildup(long id)
        {
            var ratebuildup = await _context.RateBuildUp.FindAsync(id);
            if (ratebuildup == null)
            {
                return NotFound();
            }

            _context.RateBuildUp.Remove(ratebuildup);
            await _context.SaveChangesAsync();

            return ratebuildup;
        }

        private bool RatebuildupExists(long id)
        {
            return _context.RateBuildUp.Any(e => e.Id == id);
        }
    }
}
