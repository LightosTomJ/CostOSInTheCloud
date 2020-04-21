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
    public class LayoutcController : ControllerBase
    {
        private readonly localContext _context;

        public LayoutcController(localContext context)
        {
            _context = context;
        }

        // GET: api/Layoutc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Layoutc>>> GetLayoutc()
        {
            return await _context.Layoutc.ToListAsync();
        }

        // GET: api/Layoutc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Layoutc>> GetLayoutc(long id)
        {
            var layoutc = await _context.Layoutc.FindAsync(id);

            if (layoutc == null)
            {
                return NotFound();
            }

            return layoutc;
        }

        // PUT: api/Layoutc/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayoutc(long id, Layoutc layoutc)
        {
            if (id != layoutc.Layoutcid)
            {
                return BadRequest();
            }

            _context.Entry(layoutc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayoutcExists(id))
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

        // POST: api/Layoutc
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Layoutc>> PostLayoutc(Layoutc layoutc)
        {
            _context.Layoutc.Add(layoutc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayoutc", new { id = layoutc.Layoutcid }, layoutc);
        }

        // DELETE: api/Layoutc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Layoutc>> DeleteLayoutc(long id)
        {
            var layoutc = await _context.Layoutc.FindAsync(id);
            if (layoutc == null)
            {
                return NotFound();
            }

            _context.Layoutc.Remove(layoutc);
            await _context.SaveChangesAsync();

            return layoutc;
        }

        private bool LayoutcExists(long id)
        {
            return _context.Layoutc.Any(e => e.Layoutcid == id);
        }
    }
}
