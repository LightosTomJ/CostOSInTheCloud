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
    public class QuoteitemController : ControllerBase
    {
        private readonly projectContext _context;

        public QuoteitemController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Quoteitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quoteitem>>> GetQuoteitem()
        {
            return await _context.Quoteitem.ToListAsync();
        }

        // GET: api/Quoteitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quoteitem>> GetQuoteitem(long id)
        {
            var quoteitem = await _context.Quoteitem.FindAsync(id);

            if (quoteitem == null)
            {
                return NotFound();
            }

            return quoteitem;
        }

        // PUT: api/Quoteitem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteitem(long id, Quoteitem quoteitem)
        {
            if (id != quoteitem.Quoteitemid)
            {
                return BadRequest();
            }

            _context.Entry(quoteitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteitemExists(id))
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

        // POST: api/Quoteitem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Quoteitem>> PostQuoteitem(Quoteitem quoteitem)
        {
            _context.Quoteitem.Add(quoteitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuoteitem", new { id = quoteitem.Quoteitemid }, quoteitem);
        }

        // DELETE: api/Quoteitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quoteitem>> DeleteQuoteitem(long id)
        {
            var quoteitem = await _context.Quoteitem.FindAsync(id);
            if (quoteitem == null)
            {
                return NotFound();
            }

            _context.Quoteitem.Remove(quoteitem);
            await _context.SaveChangesAsync();

            return quoteitem;
        }

        private bool QuoteitemExists(long id)
        {
            return _context.Quoteitem.Any(e => e.Quoteitemid == id);
        }
    }
}
