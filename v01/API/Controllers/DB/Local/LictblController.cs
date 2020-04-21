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
    public class LictblController : ControllerBase
    {
        private readonly localContext _context;

        public LictblController(localContext context)
        {
            _context = context;
        }

        // GET: api/Lictbl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lictbl>>> GetLictbl()
        {
            return await _context.Lictbl.ToListAsync();
        }

        // GET: api/Lictbl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lictbl>> GetLictbl(long id)
        {
            var lictbl = await _context.Lictbl.FindAsync(id);

            if (lictbl == null)
            {
                return NotFound();
            }

            return lictbl;
        }

        // PUT: api/Lictbl/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLictbl(long id, Lictbl lictbl)
        {
            if (id != lictbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(lictbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LictblExists(id))
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

        // POST: api/Lictbl
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lictbl>> PostLictbl(Lictbl lictbl)
        {
            _context.Lictbl.Add(lictbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLictbl", new { id = lictbl.Id }, lictbl);
        }

        // DELETE: api/Lictbl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lictbl>> DeleteLictbl(long id)
        {
            var lictbl = await _context.Lictbl.FindAsync(id);
            if (lictbl == null)
            {
                return NotFound();
            }

            _context.Lictbl.Remove(lictbl);
            await _context.SaveChangesAsync();

            return lictbl;
        }

        private bool LictblExists(long id)
        {
            return _context.Lictbl.Any(e => e.Id == id);
        }
    }
}
