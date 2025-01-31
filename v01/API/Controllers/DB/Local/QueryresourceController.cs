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
    public class QueryresourceController : ControllerBase
    {
        private readonly LocalContext _context;

        public QueryresourceController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Queryresource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueryResource>>> GetQueryresource()
        {
            return await _context.QueryResource.ToListAsync();
        }

        // GET: api/Queryresource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QueryResource>> GetQueryresource(long id)
        {
            var queryresource = await _context.QueryResource.FindAsync(id);

            if (queryresource == null)
            {
                return NotFound();
            }

            return queryresource;
        }

        // PUT: api/Queryresource/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueryresource(long id, QueryResource queryresource)
        {
            if (id != queryresource.Qresid)
            {
                return BadRequest();
            }

            _context.Entry(queryresource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryresourceExists(id))
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

        // POST: api/Queryresource
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QueryResource>> PostQueryresource(QueryResource queryresource)
        {
            _context.QueryResource.Add(queryresource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueryresource", new { id = queryresource.Qresid }, queryresource);
        }

        // DELETE: api/Queryresource/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QueryResource>> DeleteQueryresource(long id)
        {
            var queryresource = await _context.QueryResource.FindAsync(id);
            if (queryresource == null)
            {
                return NotFound();
            }

            _context.QueryResource.Remove(queryresource);
            await _context.SaveChangesAsync();

            return queryresource;
        }

        private bool QueryresourceExists(long id)
        {
            return _context.QueryResource.Any(e => e.Qresid == id);
        }
    }
}
