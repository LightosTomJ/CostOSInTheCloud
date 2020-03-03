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
    public class ExtdatasourceController : ControllerBase
    {
        private readonly localContext _context;

        public ExtdatasourceController(localContext context)
        {
            _context = context;
        }

        // GET: api/Extdatasource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extdatasource>>> GetExtdatasource()
        {
            return await _context.Extdatasource.ToListAsync();
        }

        // GET: api/Extdatasource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extdatasource>> GetExtdatasource(long id)
        {
            var extdatasource = await _context.Extdatasource.FindAsync(id);

            if (extdatasource == null)
            {
                return NotFound();
            }

            return extdatasource;
        }

        // PUT: api/Extdatasource/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtdatasource(long id, Extdatasource extdatasource)
        {
            if (id != extdatasource.Datasourceid)
            {
                return BadRequest();
            }

            _context.Entry(extdatasource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtdatasourceExists(id))
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

        // POST: api/Extdatasource
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Extdatasource>> PostExtdatasource(Extdatasource extdatasource)
        {
            _context.Extdatasource.Add(extdatasource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtdatasource", new { id = extdatasource.Datasourceid }, extdatasource);
        }

        // DELETE: api/Extdatasource/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extdatasource>> DeleteExtdatasource(long id)
        {
            var extdatasource = await _context.Extdatasource.FindAsync(id);
            if (extdatasource == null)
            {
                return NotFound();
            }

            _context.Extdatasource.Remove(extdatasource);
            await _context.SaveChangesAsync();

            return extdatasource;
        }

        private bool ExtdatasourceExists(long id)
        {
            return _context.Extdatasource.Any(e => e.Datasourceid == id);
        }
    }
}
