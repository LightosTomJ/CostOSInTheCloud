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
    public class SubcontractorController : ControllerBase
    {
        private readonly localContext _context;

        public SubcontractorController(localContext context)
        {
            _context = context;
        }

        // GET: api/Subcontractor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcontractor>>> GetSubcontractor()
        {
            return await _context.Subcontractor.ToListAsync();
        }

        // GET: api/Subcontractor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subcontractor>> GetSubcontractor(long id)
        {
            var subcontractor = await _context.Subcontractor.FindAsync(id);

            if (subcontractor == null)
            {
                return NotFound();
            }

            return subcontractor;
        }

        // PUT: api/Subcontractor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcontractor(long id, Subcontractor subcontractor)
        {
            if (id != subcontractor.Subcontractorid)
            {
                return BadRequest();
            }

            _context.Entry(subcontractor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcontractorExists(id))
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

        // POST: api/Subcontractor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subcontractor>> PostSubcontractor(Subcontractor subcontractor)
        {
            _context.Subcontractor.Add(subcontractor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcontractor", new { id = subcontractor.Subcontractorid }, subcontractor);
        }

        // DELETE: api/Subcontractor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subcontractor>> DeleteSubcontractor(long id)
        {
            var subcontractor = await _context.Subcontractor.FindAsync(id);
            if (subcontractor == null)
            {
                return NotFound();
            }

            _context.Subcontractor.Remove(subcontractor);
            await _context.SaveChangesAsync();

            return subcontractor;
        }

        private bool SubcontractorExists(long id)
        {
            return _context.Subcontractor.Any(e => e.Subcontractorid == id);
        }
    }
}
