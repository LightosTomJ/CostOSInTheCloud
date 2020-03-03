using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Utils;

namespace ClientBlazor.Server.Controllers.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceholderController : ControllerBase
    {
        private readonly utilsContext _context;

        public PlaceholderController(utilsContext context)
        {
            _context = context;
        }

        // GET: api/Placeholder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Placeholder>>> GetPlaceholder()
        {
            return await _context.Placeholder.ToListAsync();
        }

        // GET: api/Placeholder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Placeholder>> GetPlaceholder(long id)
        {
            var placeholder = await _context.Placeholder.FindAsync(id);

            if (placeholder == null)
            {
                return NotFound();
            }

            return placeholder;
        }

        // PUT: api/Placeholder/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaceholder(long id, Placeholder placeholder)
        {
            if (id != placeholder.Id)
            {
                return BadRequest();
            }

            _context.Entry(placeholder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceholderExists(id))
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

        // POST: api/Placeholder
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Placeholder>> PostPlaceholder(Placeholder placeholder)
        {
            _context.Placeholder.Add(placeholder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaceholder", new { id = placeholder.Id }, placeholder);
        }

        // DELETE: api/Placeholder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Placeholder>> DeletePlaceholder(long id)
        {
            var placeholder = await _context.Placeholder.FindAsync(id);
            if (placeholder == null)
            {
                return NotFound();
            }

            _context.Placeholder.Remove(placeholder);
            await _context.SaveChangesAsync();

            return placeholder;
        }

        private bool PlaceholderExists(long id)
        {
            return _context.Placeholder.Any(e => e.Id == id);
        }
    }
}
