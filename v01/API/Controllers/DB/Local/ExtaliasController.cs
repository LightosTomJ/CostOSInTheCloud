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
    public class ExtaliasController : ControllerBase
    {
        private readonly LocalContext _context;

        public ExtaliasController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Extalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtAlias>>> GetExtalias()
        {
            return await _context.ExtAlias.ToListAsync();
        }

        // GET: api/Extalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtAlias>> GetExtalias(long id)
        {
            var extalias = await _context.ExtAlias.FindAsync(id);

            if (extalias == null)
            {
                return NotFound();
            }

            return extalias;
        }

        // PUT: api/Extalias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtalias(long id, ExtAlias extalias)
        {
            if (id != extalias.Aliasid)
            {
                return BadRequest();
            }

            _context.Entry(extalias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtaliasExists(id))
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

        // POST: api/Extalias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExtAlias>> PostExtalias(ExtAlias extalias)
        {
            _context.ExtAlias.Add(extalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtalias", new { id = extalias.Aliasid }, extalias);
        }

        // DELETE: api/Extalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExtAlias>> DeleteExtalias(long id)
        {
            var extalias = await _context.ExtAlias.FindAsync(id);
            if (extalias == null)
            {
                return NotFound();
            }

            _context.ExtAlias.Remove(extalias);
            await _context.SaveChangesAsync();

            return extalias;
        }

        private bool ExtaliasExists(long id)
        {
            return _context.ExtAlias.Any(e => e.Aliasid == id);
        }
    }
}
