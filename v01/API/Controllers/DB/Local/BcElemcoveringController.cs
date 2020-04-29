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
    public class BcElemcoveringController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcElemcoveringController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcElemcovering
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemCovering>>> GetBcElemcovering()
        {
            return await _context.BcElemCovering.ToListAsync();
        }

        // GET: api/BcElemcovering/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemCovering>> GetBcElemcovering(long id)
        {
            var bcElemcovering = await _context.BcElemCovering.FindAsync(id);

            if (bcElemcovering == null)
            {
                return NotFound();
            }

            return bcElemcovering;
        }

        // PUT: api/BcElemcovering/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemcovering(long id, BcElemCovering bcElemcovering)
        {
            if (id != bcElemcovering.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemcovering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElemcoveringExists(id))
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

        // POST: api/BcElemcovering
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElemCovering>> PostBcElemcovering(BcElemCovering bcElemcovering)
        {
            _context.BcElemCovering.Add(bcElemcovering);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemcovering", new { id = bcElemcovering.Id }, bcElemcovering);
        }

        // DELETE: api/BcElemcovering/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemCovering>> DeleteBcElemcovering(long id)
        {
            var bcElemcovering = await _context.BcElemCovering.FindAsync(id);
            if (bcElemcovering == null)
            {
                return NotFound();
            }

            _context.BcElemCovering.Remove(bcElemcovering);
            await _context.SaveChangesAsync();

            return bcElemcovering;
        }

        private bool BcElemcoveringExists(long id)
        {
            return _context.BcElemCovering.Any(e => e.Id == id);
        }
    }
}
