using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryresourceController : ControllerBase
    {
        private readonly projectContext _context;

        public QueryresourceController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Queryresource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Queryresource>>> GetQueryresource()
        {
            return await _context.Queryresource.ToListAsync();
        }

        // GET: api/Queryresource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Queryresource>> GetQueryresource(long id)
        {
            var queryresource = await _context.Queryresource.FindAsync(id);

            if (queryresource == null)
            {
                return NotFound();
            }

            return queryresource;
        }

        // PUT: api/Queryresource/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueryresource(long id, Queryresource queryresource)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Queryresource>> PostQueryresource(Queryresource queryresource)
        {
            _context.Queryresource.Add(queryresource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueryresource", new { id = queryresource.Qresid }, queryresource);
        }

        // DELETE: api/Queryresource/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Queryresource>> DeleteQueryresource(long id)
        {
            var queryresource = await _context.Queryresource.FindAsync(id);
            if (queryresource == null)
            {
                return NotFound();
            }

            _context.Queryresource.Remove(queryresource);
            await _context.SaveChangesAsync();

            return queryresource;
        }

        private bool QueryresourceExists(long id)
        {
            return _context.Queryresource.Any(e => e.Qresid == id);
        }
    }
}
