using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public PartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/Partial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partial>>> GetPartial()
        {
            return await _context.Partial.ToListAsync();
        }

        // GET: api/Partial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partial>> GetPartial(int id)
        {
            var @partial = await _context.Partial.FindAsync(id);

            if (@partial == null)
            {
                return NotFound();
            }

            return @partial;
        }

        // PUT: api/Partial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartial(int id, Partial @partial)
        {
            if (id != @partial.Id)
            {
                return BadRequest();
            }

            _context.Entry(@partial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialExists(id))
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

        // POST: api/Partial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Partial>> PostPartial(Partial @partial)
        {
            _context.Partial.Add(@partial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartialExists(@partial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartial", new { id = @partial.Id }, @partial);
        }

        // DELETE: api/Partial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Partial>> DeletePartial(int id)
        {
            var @partial = await _context.Partial.FindAsync(id);
            if (@partial == null)
            {
                return NotFound();
            }

            _context.Partial.Remove(@partial);
            await _context.SaveChangesAsync();

            return @partial;
        }

        private bool PartialExists(int id)
        {
            return _context.Partial.Any(e => e.Id == id);
        }
    }
}
