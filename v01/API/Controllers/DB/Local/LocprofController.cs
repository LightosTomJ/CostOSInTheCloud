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
        private readonly LocalContext _context;

        public LocprofController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Locprof
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocProf>>> GetLocprof()
        {
            return await _context.LocProf.ToListAsync();
        }

        // GET: api/Locprof/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocProf>> GetLocprof(long id)
        {
            var locprof = await _context.LocProf.FindAsync(id);

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
        public async Task<IActionResult> PutLocprof(long id, LocProf locprof)
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
        public async Task<ActionResult<LocProf>> PostLocprof(LocProf locprof)
        {
            _context.LocProf.Add(locprof);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocprof", new { id = locprof.Functionid }, locprof);
        }

        // DELETE: api/Locprof/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocProf>> DeleteLocprof(long id)
        {
            var locprof = await _context.LocProf.FindAsync(id);
            if (locprof == null)
            {
                return NotFound();
            }

            _context.LocProf.Remove(locprof);
            await _context.SaveChangesAsync();

            return locprof;
        }

        private bool LocprofExists(long id)
        {
            return _context.LocProf.Any(e => e.Functionid == id);
        }
    }
}
