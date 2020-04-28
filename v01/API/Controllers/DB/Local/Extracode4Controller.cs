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
    public class Extracode4Controller : ControllerBase
    {
        private readonly LocalContext _context;

        public Extracode4Controller(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Extracode4
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode4>>> GetExtracode4()
        {
            return await _context.Extracode4.ToListAsync();
        }

        // GET: api/Extracode4/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode4>> GetExtracode4(long id)
        {
            var extracode4 = await _context.Extracode4.FindAsync(id);

            if (extracode4 == null)
            {
                return NotFound();
            }

            return extracode4;
        }

        // PUT: api/Extracode4/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode4(long id, Extracode4 extracode4)
        {
            if (id != extracode4.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode4).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode4Exists(id))
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

        // POST: api/Extracode4
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extracode4>> PostExtracode4(Extracode4 extracode4)
        {
            _context.Extracode4.Add(extracode4);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode4", new { id = extracode4.Groupcodeid }, extracode4);
        }

        // DELETE: api/Extracode4/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode4>> DeleteExtracode4(long id)
        {
            var extracode4 = await _context.Extracode4.FindAsync(id);
            if (extracode4 == null)
            {
                return NotFound();
            }

            _context.Extracode4.Remove(extracode4);
            await _context.SaveChangesAsync();

            return extracode4;
        }

        private bool Extracode4Exists(long id)
        {
            return _context.Extracode4.Any(e => e.Groupcodeid == id);
        }
    }
}
