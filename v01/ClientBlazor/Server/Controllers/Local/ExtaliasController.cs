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
    public class ExtaliasController : ControllerBase
    {
        private readonly localContext _context;

        public ExtaliasController(localContext context)
        {
            _context = context;
        }

        // GET: api/Extalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extalias>>> GetExtalias()
        {
            return await _context.Extalias.ToListAsync();
        }

        // GET: api/Extalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extalias>> GetExtalias(long id)
        {
            var extalias = await _context.Extalias.FindAsync(id);

            if (extalias == null)
            {
                return NotFound();
            }

            return extalias;
        }

        // PUT: api/Extalias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtalias(long id, Extalias extalias)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Extalias>> PostExtalias(Extalias extalias)
        {
            _context.Extalias.Add(extalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtalias", new { id = extalias.Aliasid }, extalias);
        }

        // DELETE: api/Extalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extalias>> DeleteExtalias(long id)
        {
            var extalias = await _context.Extalias.FindAsync(id);
            if (extalias == null)
            {
                return NotFound();
            }

            _context.Extalias.Remove(extalias);
            await _context.SaveChangesAsync();

            return extalias;
        }

        private bool ExtaliasExists(long id)
        {
            return _context.Extalias.Any(e => e.Aliasid == id);
        }
    }
}
