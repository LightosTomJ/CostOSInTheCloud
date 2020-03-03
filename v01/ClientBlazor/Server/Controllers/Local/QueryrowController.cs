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
    public class QueryrowController : ControllerBase
    {
        private readonly localContext _context;

        public QueryrowController(localContext context)
        {
            _context = context;
        }

        // GET: api/Queryrow
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Queryrow>>> GetQueryrow()
        {
            return await _context.Queryrow.ToListAsync();
        }

        // GET: api/Queryrow/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Queryrow>> GetQueryrow(long id)
        {
            var queryrow = await _context.Queryrow.FindAsync(id);

            if (queryrow == null)
            {
                return NotFound();
            }

            return queryrow;
        }

        // PUT: api/Queryrow/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueryrow(long id, Queryrow queryrow)
        {
            if (id != queryrow.Qrowid)
            {
                return BadRequest();
            }

            _context.Entry(queryrow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryrowExists(id))
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

        // POST: api/Queryrow
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Queryrow>> PostQueryrow(Queryrow queryrow)
        {
            _context.Queryrow.Add(queryrow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueryrow", new { id = queryrow.Qrowid }, queryrow);
        }

        // DELETE: api/Queryrow/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Queryrow>> DeleteQueryrow(long id)
        {
            var queryrow = await _context.Queryrow.FindAsync(id);
            if (queryrow == null)
            {
                return NotFound();
            }

            _context.Queryrow.Remove(queryrow);
            await _context.SaveChangesAsync();

            return queryrow;
        }

        private bool QueryrowExists(long id)
        {
            return _context.Queryrow.Any(e => e.Qrowid == id);
        }
    }
}
