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
    public class GekcodeController : ControllerBase
    {
        private readonly localContext _context;

        public GekcodeController(localContext context)
        {
            _context = context;
        }

        // GET: api/Gekcode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gekcode>>> GetGekcode()
        {
            return await _context.Gekcode.ToListAsync();
        }

        // GET: api/Gekcode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gekcode>> GetGekcode(long id)
        {
            var gekcode = await _context.Gekcode.FindAsync(id);

            if (gekcode == null)
            {
                return NotFound();
            }

            return gekcode;
        }

        // PUT: api/Gekcode/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGekcode(long id, Gekcode gekcode)
        {
            if (id != gekcode.Gekcodeid)
            {
                return BadRequest();
            }

            _context.Entry(gekcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GekcodeExists(id))
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

        // POST: api/Gekcode
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gekcode>> PostGekcode(Gekcode gekcode)
        {
            _context.Gekcode.Add(gekcode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGekcode", new { id = gekcode.Gekcodeid }, gekcode);
        }

        // DELETE: api/Gekcode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gekcode>> DeleteGekcode(long id)
        {
            var gekcode = await _context.Gekcode.FindAsync(id);
            if (gekcode == null)
            {
                return NotFound();
            }

            _context.Gekcode.Remove(gekcode);
            await _context.SaveChangesAsync();

            return gekcode;
        }

        private bool GekcodeExists(long id)
        {
            return _context.Gekcode.Any(e => e.Gekcodeid == id);
        }
    }
}
