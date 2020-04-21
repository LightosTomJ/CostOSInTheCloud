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
    public class Extracode6Controller : ControllerBase
    {
        private readonly localContext _context;

        public Extracode6Controller(localContext context)
        {
            _context = context;
        }

        // GET: api/Extracode6
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode6>>> GetExtracode6()
        {
            return await _context.Extracode6.ToListAsync();
        }

        // GET: api/Extracode6/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode6>> GetExtracode6(long id)
        {
            var extracode6 = await _context.Extracode6.FindAsync(id);

            if (extracode6 == null)
            {
                return NotFound();
            }

            return extracode6;
        }

        // PUT: api/Extracode6/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode6(long id, Extracode6 extracode6)
        {
            if (id != extracode6.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode6).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode6Exists(id))
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

        // POST: api/Extracode6
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extracode6>> PostExtracode6(Extracode6 extracode6)
        {
            _context.Extracode6.Add(extracode6);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode6", new { id = extracode6.Groupcodeid }, extracode6);
        }

        // DELETE: api/Extracode6/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode6>> DeleteExtracode6(long id)
        {
            var extracode6 = await _context.Extracode6.FindAsync(id);
            if (extracode6 == null)
            {
                return NotFound();
            }

            _context.Extracode6.Remove(extracode6);
            await _context.SaveChangesAsync();

            return extracode6;
        }

        private bool Extracode6Exists(long id)
        {
            return _context.Extracode6.Any(e => e.Groupcodeid == id);
        }
    }
}
