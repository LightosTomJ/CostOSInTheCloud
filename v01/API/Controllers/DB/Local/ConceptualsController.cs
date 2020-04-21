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
    public class ConceptualsController : ControllerBase
    {
        private readonly localContext _context;

        public ConceptualsController(localContext context)
        {
            _context = context;
        }

        // GET: api/Conceptuals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conceptuals>>> GetConceptuals()
        {
            return await _context.Conceptuals.ToListAsync();
        }

        // GET: api/Conceptuals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conceptuals>> GetConceptuals(long id)
        {
            var conceptuals = await _context.Conceptuals.FindAsync(id);

            if (conceptuals == null)
            {
                return NotFound();
            }

            return conceptuals;
        }

        // PUT: api/Conceptuals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConceptuals(long id, Conceptuals conceptuals)
        {
            if (id != conceptuals.Conceptualid)
            {
                return BadRequest();
            }

            _context.Entry(conceptuals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptualsExists(id))
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

        // POST: api/Conceptuals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Conceptuals>> PostConceptuals(Conceptuals conceptuals)
        {
            _context.Conceptuals.Add(conceptuals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConceptuals", new { id = conceptuals.Conceptualid }, conceptuals);
        }

        // DELETE: api/Conceptuals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conceptuals>> DeleteConceptuals(long id)
        {
            var conceptuals = await _context.Conceptuals.FindAsync(id);
            if (conceptuals == null)
            {
                return NotFound();
            }

            _context.Conceptuals.Remove(conceptuals);
            await _context.SaveChangesAsync();

            return conceptuals;
        }

        private bool ConceptualsExists(long id)
        {
            return _context.Conceptuals.Any(e => e.Conceptualid == id);
        }
    }
}
