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
    public class UnitaliasController : ControllerBase
    {
        private readonly LocalContext _context;

        public UnitaliasController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Unitalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitAlias>>> GetUnitalias()
        {
            return await _context.UnitAlias.ToListAsync();
        }

        // GET: api/Unitalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitAlias>> GetUnitalias(long id)
        {
            var unitalias = await _context.UnitAlias.FindAsync(id);

            if (unitalias == null)
            {
                return NotFound();
            }

            return unitalias;
        }

        // PUT: api/Unitalias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitalias(long id, UnitAlias unitalias)
        {
            if (id != unitalias.Id)
            {
                return BadRequest();
            }

            _context.Entry(unitalias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitaliasExists(id))
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

        // POST: api/Unitalias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UnitAlias>> PostUnitalias(UnitAlias unitalias)
        {
            _context.UnitAlias.Add(unitalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitalias", new { id = unitalias.Id }, unitalias);
        }

        // DELETE: api/Unitalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitAlias>> DeleteUnitalias(long id)
        {
            var unitalias = await _context.UnitAlias.FindAsync(id);
            if (unitalias == null)
            {
                return NotFound();
            }

            _context.UnitAlias.Remove(unitalias);
            await _context.SaveChangesAsync();

            return unitalias;
        }

        private bool UnitaliasExists(long id)
        {
            return _context.UnitAlias.Any(e => e.Id == id);
        }
    }
}
