using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitaliasController : ControllerBase
    {
        private readonly localContext _context;

        public UnitaliasController(localContext context)
        {
            _context = context;
        }

        // GET: api/Unitalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unitalias>>> GetUnitalias()
        {
            return await _context.Unitalias.ToListAsync();
        }

        // GET: api/Unitalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unitalias>> GetUnitalias(long id)
        {
            var unitalias = await _context.Unitalias.FindAsync(id);

            if (unitalias == null)
            {
                return NotFound();
            }

            return unitalias;
        }

        // PUT: api/Unitalias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitalias(long id, Unitalias unitalias)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Unitalias>> PostUnitalias(Unitalias unitalias)
        {
            _context.Unitalias.Add(unitalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitalias", new { id = unitalias.Id }, unitalias);
        }

        // DELETE: api/Unitalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unitalias>> DeleteUnitalias(long id)
        {
            var unitalias = await _context.Unitalias.FindAsync(id);
            if (unitalias == null)
            {
                return NotFound();
            }

            _context.Unitalias.Remove(unitalias);
            await _context.SaveChangesAsync();

            return unitalias;
        }

        private bool UnitaliasExists(long id)
        {
            return _context.Unitalias.Any(e => e.Id == id);
        }
    }
}