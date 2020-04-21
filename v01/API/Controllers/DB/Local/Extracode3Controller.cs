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
    public class Extracode3Controller : ControllerBase
    {
        private readonly localContext _context;

        public Extracode3Controller(localContext context)
        {
            _context = context;
        }

        // GET: api/Extracode3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode3>>> GetExtracode3()
        {
            return await _context.Extracode3.ToListAsync();
        }

        // GET: api/Extracode3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode3>> GetExtracode3(long id)
        {
            var extracode3 = await _context.Extracode3.FindAsync(id);

            if (extracode3 == null)
            {
                return NotFound();
            }

            return extracode3;
        }

        // PUT: api/Extracode3/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode3(long id, Extracode3 extracode3)
        {
            if (id != extracode3.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode3Exists(id))
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

        // POST: api/Extracode3
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extracode3>> PostExtracode3(Extracode3 extracode3)
        {
            _context.Extracode3.Add(extracode3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode3", new { id = extracode3.Groupcodeid }, extracode3);
        }

        // DELETE: api/Extracode3/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode3>> DeleteExtracode3(long id)
        {
            var extracode3 = await _context.Extracode3.FindAsync(id);
            if (extracode3 == null)
            {
                return NotFound();
            }

            _context.Extracode3.Remove(extracode3);
            await _context.SaveChangesAsync();

            return extracode3;
        }

        private bool Extracode3Exists(long id)
        {
            return _context.Extracode3.Any(e => e.Groupcodeid == id);
        }
    }
}
