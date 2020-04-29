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
    public class ExtqueryController : ControllerBase
    {
        private readonly LocalContext _context;

        public ExtqueryController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Extquery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtQuery>>> GetExtquery()
        {
            return await _context.ExtQuery.ToListAsync();
        }

        // GET: api/Extquery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtQuery>> GetExtquery(long id)
        {
            var extquery = await _context.ExtQuery.FindAsync(id);

            if (extquery == null)
            {
                return NotFound();
            }

            return extquery;
        }

        // PUT: api/Extquery/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtquery(long id, ExtQuery extquery)
        {
            if (id != extquery.Queryid)
            {
                return BadRequest();
            }

            _context.Entry(extquery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtqueryExists(id))
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

        // POST: api/Extquery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExtQuery>> PostExtquery(ExtQuery extquery)
        {
            _context.ExtQuery.Add(extquery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtquery", new { id = extquery.Queryid }, extquery);
        }

        // DELETE: api/Extquery/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExtQuery>> DeleteExtquery(long id)
        {
            var extquery = await _context.ExtQuery.FindAsync(id);
            if (extquery == null)
            {
                return NotFound();
            }

            _context.ExtQuery.Remove(extquery);
            await _context.SaveChangesAsync();

            return extquery;
        }

        private bool ExtqueryExists(long id)
        {
            return _context.ExtQuery.Any(e => e.Queryid == id);
        }
    }
}
