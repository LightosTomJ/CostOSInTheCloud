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
    public class LocprofController : ControllerBase
    {
        private readonly localContext _context;

        public LocprofController(localContext context)
        {
            _context = context;
        }

        // GET: api/Locprof
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locprof>>> GetLocprof()
        {
            return await _context.Locprof.ToListAsync();
        }

        // GET: api/Locprof/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locprof>> GetLocprof(long id)
        {
            var locprof = await _context.Locprof.FindAsync(id);

            if (locprof == null)
            {
                return NotFound();
            }

            return locprof;
        }

        // PUT: api/Locprof/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocprof(long id, Locprof locprof)
        {
            if (id != locprof.Functionid)
            {
                return BadRequest();
            }

            _context.Entry(locprof).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocprofExists(id))
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

        // POST: api/Locprof
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Locprof>> PostLocprof(Locprof locprof)
        {
            _context.Locprof.Add(locprof);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocprof", new { id = locprof.Functionid }, locprof);
        }

        // DELETE: api/Locprof/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Locprof>> DeleteLocprof(long id)
        {
            var locprof = await _context.Locprof.FindAsync(id);
            if (locprof == null)
            {
                return NotFound();
            }

            _context.Locprof.Remove(locprof);
            await _context.SaveChangesAsync();

            return locprof;
        }

        private bool LocprofExists(long id)
        {
            return _context.Locprof.Any(e => e.Functionid == id);
        }
    }
}
