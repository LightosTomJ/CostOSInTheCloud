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
    public class QueryrowController : ControllerBase
    {
        private readonly LocalContext _context;

        public QueryrowController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Queryrow
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueryRow>>> GetQueryrow()
        {
            return await _context.QueryRow.ToListAsync();
        }

        // GET: api/Queryrow/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QueryRow>> GetQueryrow(long id)
        {
            var queryrow = await _context.QueryRow.FindAsync(id);

            if (queryrow == null)
            {
                return NotFound();
            }

            return queryrow;
        }

        // PUT: api/Queryrow/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueryrow(long id, QueryRow queryrow)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QueryRow>> PostQueryrow(QueryRow queryrow)
        {
            _context.QueryRow.Add(queryrow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueryrow", new { id = queryrow.Qrowid }, queryrow);
        }

        // DELETE: api/Queryrow/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QueryRow>> DeleteQueryrow(long id)
        {
            var queryrow = await _context.QueryRow.FindAsync(id);
            if (queryrow == null)
            {
                return NotFound();
            }

            _context.QueryRow.Remove(queryrow);
            await _context.SaveChangesAsync();

            return queryrow;
        }

        private bool QueryrowExists(long id)
        {
            return _context.QueryRow.Any(e => e.Qrowid == id);
        }
    }
}
