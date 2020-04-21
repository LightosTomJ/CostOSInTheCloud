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
    public class Extracode7Controller : ControllerBase
    {
        private readonly localContext _context;

        public Extracode7Controller(localContext context)
        {
            _context = context;
        }

        // GET: api/Extracode7
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode7>>> GetExtracode7()
        {
            return await _context.Extracode7.ToListAsync();
        }

        // GET: api/Extracode7/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode7>> GetExtracode7(long id)
        {
            var extracode7 = await _context.Extracode7.FindAsync(id);

            if (extracode7 == null)
            {
                return NotFound();
            }

            return extracode7;
        }

        // PUT: api/Extracode7/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode7(long id, Extracode7 extracode7)
        {
            if (id != extracode7.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode7).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode7Exists(id))
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

        // POST: api/Extracode7
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extracode7>> PostExtracode7(Extracode7 extracode7)
        {
            _context.Extracode7.Add(extracode7);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode7", new { id = extracode7.Groupcodeid }, extracode7);
        }

        // DELETE: api/Extracode7/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode7>> DeleteExtracode7(long id)
        {
            var extracode7 = await _context.Extracode7.FindAsync(id);
            if (extracode7 == null)
            {
                return NotFound();
            }

            _context.Extracode7.Remove(extracode7);
            await _context.SaveChangesAsync();

            return extracode7;
        }

        private bool Extracode7Exists(long id)
        {
            return _context.Extracode7.Any(e => e.Groupcodeid == id);
        }
    }
}
