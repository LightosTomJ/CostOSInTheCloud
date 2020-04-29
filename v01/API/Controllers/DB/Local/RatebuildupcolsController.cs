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
    public class RatebuildupcolsController : ControllerBase
    {
        private readonly LocalContext _context;

        public RatebuildupcolsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Ratebuildupcols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateBuildUpCols>>> GetRatebuildupcols()
        {
            return await _context.RateBuildUpCols.ToListAsync();
        }

        // GET: api/Ratebuildupcols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateBuildUpCols>> GetRatebuildupcols(long id)
        {
            var ratebuildupcols = await _context.RateBuildUpCols.FindAsync(id);

            if (ratebuildupcols == null)
            {
                return NotFound();
            }

            return ratebuildupcols;
        }

        // PUT: api/Ratebuildupcols/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatebuildupcols(long id, RateBuildUpCols ratebuildupcols)
        {
            if (id != ratebuildupcols.Id)
            {
                return BadRequest();
            }

            _context.Entry(ratebuildupcols).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatebuildupcolsExists(id))
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

        // POST: api/Ratebuildupcols
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RateBuildUpCols>> PostRatebuildupcols(RateBuildUpCols ratebuildupcols)
        {
            _context.RateBuildUpCols.Add(ratebuildupcols);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatebuildupcols", new { id = ratebuildupcols.Id }, ratebuildupcols);
        }

        // DELETE: api/Ratebuildupcols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RateBuildUpCols>> DeleteRatebuildupcols(long id)
        {
            var ratebuildupcols = await _context.RateBuildUpCols.FindAsync(id);
            if (ratebuildupcols == null)
            {
                return NotFound();
            }

            _context.RateBuildUpCols.Remove(ratebuildupcols);
            await _context.SaveChangesAsync();

            return ratebuildupcols;
        }

        private bool RatebuildupcolsExists(long id)
        {
            return _context.RateBuildUpCols.Any(e => e.Id == id);
        }
    }
}
