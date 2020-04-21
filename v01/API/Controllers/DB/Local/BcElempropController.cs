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
    public class BcElempropController : ControllerBase
    {
        private readonly localContext _context;

        public BcElempropController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElemprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemprop>>> GetBcElemprop()
        {
            return await _context.BcElemprop.ToListAsync();
        }

        // GET: api/BcElemprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemprop>> GetBcElemprop(long id)
        {
            var bcElemprop = await _context.BcElemprop.FindAsync(id);

            if (bcElemprop == null)
            {
                return NotFound();
            }

            return bcElemprop;
        }

        // PUT: api/BcElemprop/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemprop(long id, BcElemprop bcElemprop)
        {
            if (id != bcElemprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElempropExists(id))
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

        // POST: api/BcElemprop
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElemprop>> PostBcElemprop(BcElemprop bcElemprop)
        {
            _context.BcElemprop.Add(bcElemprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemprop", new { id = bcElemprop.Id }, bcElemprop);
        }

        // DELETE: api/BcElemprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemprop>> DeleteBcElemprop(long id)
        {
            var bcElemprop = await _context.BcElemprop.FindAsync(id);
            if (bcElemprop == null)
            {
                return NotFound();
            }

            _context.BcElemprop.Remove(bcElemprop);
            await _context.SaveChangesAsync();

            return bcElemprop;
        }

        private bool BcElempropExists(long id)
        {
            return _context.BcElemprop.Any(e => e.Id == id);
        }
    }
}
