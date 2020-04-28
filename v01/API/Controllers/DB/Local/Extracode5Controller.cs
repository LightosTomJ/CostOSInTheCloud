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
    public class Extracode5Controller : ControllerBase
    {
        private readonly LocalContext _context;

        public Extracode5Controller(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Extracode5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode5>>> GetExtracode5()
        {
            return await _context.Extracode5.ToListAsync();
        }

        // GET: api/Extracode5/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode5>> GetExtracode5(long id)
        {
            var extracode5 = await _context.Extracode5.FindAsync(id);

            if (extracode5 == null)
            {
                return NotFound();
            }

            return extracode5;
        }

        // PUT: api/Extracode5/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode5(long id, Extracode5 extracode5)
        {
            if (id != extracode5.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode5).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode5Exists(id))
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

        // POST: api/Extracode5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extracode5>> PostExtracode5(Extracode5 extracode5)
        {
            _context.Extracode5.Add(extracode5);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode5", new { id = extracode5.Groupcodeid }, extracode5);
        }

        // DELETE: api/Extracode5/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode5>> DeleteExtracode5(long id)
        {
            var extracode5 = await _context.Extracode5.FindAsync(id);
            if (extracode5 == null)
            {
                return NotFound();
            }

            _context.Extracode5.Remove(extracode5);
            await _context.SaveChangesAsync();

            return extracode5;
        }

        private bool Extracode5Exists(long id)
        {
            return _context.Extracode5.Any(e => e.Groupcodeid == id);
        }
    }
}
