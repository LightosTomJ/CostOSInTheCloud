using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class BcElemcoveringController : ControllerBase
    {
        private readonly localContext _context;

        public BcElemcoveringController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElemcovering
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemcovering>>> GetBcElemcovering()
        {
            return await _context.BcElemcovering.ToListAsync();
        }

        // GET: api/BcElemcovering/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemcovering>> GetBcElemcovering(long id)
        {
            var bcElemcovering = await _context.BcElemcovering.FindAsync(id);

            if (bcElemcovering == null)
            {
                return NotFound();
            }

            return bcElemcovering;
        }

        // PUT: api/BcElemcovering/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemcovering(long id, BcElemcovering bcElemcovering)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcElemcovering>> PostBcElemcovering(BcElemcovering bcElemcovering)
        {
            _context.BcElemcovering.Add(bcElemcovering);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemcovering", new { id = bcElemcovering.Id }, bcElemcovering);
        }

        // DELETE: api/BcElemcovering/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemcovering>> DeleteBcElemcovering(long id)
        {
            var bcElemcovering = await _context.BcElemcovering.FindAsync(id);
            if (bcElemcovering == null)
            {
                return NotFound();
            }

            _context.BcElemcovering.Remove(bcElemcovering);
            await _context.SaveChangesAsync();

            return bcElemcovering;
        }

        private bool BcElemcoveringExists(long id)
        {
            return _context.BcElemcovering.Any(e => e.Id == id);
        }
    }
}
