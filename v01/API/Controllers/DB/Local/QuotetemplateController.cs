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
    public class QuotetemplateController : ControllerBase
    {
        private readonly localContext _context;

        public QuotetemplateController(localContext context)
        {
            _context = context;
        }

        // GET: api/Quotetemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotetemplate>>> GetQuotetemplate()
        {
            return await _context.Quotetemplate.ToListAsync();
        }

        // GET: api/Quotetemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotetemplate>> GetQuotetemplate(long id)
        {
            var quotetemplate = await _context.Quotetemplate.FindAsync(id);

            if (quotetemplate == null)
            {
                return NotFound();
            }

            return quotetemplate;
        }

        // PUT: api/Quotetemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotetemplate(long id, Quotetemplate quotetemplate)
        {
            if (id != quotetemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(quotetemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotetemplateExists(id))
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

        // POST: api/Quotetemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quotetemplate>> PostQuotetemplate(Quotetemplate quotetemplate)
        {
            _context.Quotetemplate.Add(quotetemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotetemplate", new { id = quotetemplate.Id }, quotetemplate);
        }

        // DELETE: api/Quotetemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quotetemplate>> DeleteQuotetemplate(long id)
        {
            var quotetemplate = await _context.Quotetemplate.FindAsync(id);
            if (quotetemplate == null)
            {
                return NotFound();
            }

            _context.Quotetemplate.Remove(quotetemplate);
            await _context.SaveChangesAsync();

            return quotetemplate;
        }

        private bool QuotetemplateExists(long id)
        {
            return _context.Quotetemplate.Any(e => e.Id == id);
        }
    }
}
