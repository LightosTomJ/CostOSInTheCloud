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
    public class BcElemclassitemController : ControllerBase
    {
        private readonly localContext _context;

        public BcElemclassitemController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElemclassitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemclassitem>>> GetBcElemclassitem()
        {
            return await _context.BcElemclassitem.ToListAsync();
        }

        // GET: api/BcElemclassitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemclassitem>> GetBcElemclassitem(long id)
        {
            var bcElemclassitem = await _context.BcElemclassitem.FindAsync(id);

            if (bcElemclassitem == null)
            {
                return NotFound();
            }

            return bcElemclassitem;
        }

        // PUT: api/BcElemclassitem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemclassitem(long id, BcElemclassitem bcElemclassitem)
        {
            if (id != bcElemclassitem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemclassitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElemclassitemExists(id))
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

        // POST: api/BcElemclassitem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElemclassitem>> PostBcElemclassitem(BcElemclassitem bcElemclassitem)
        {
            _context.BcElemclassitem.Add(bcElemclassitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemclassitem", new { id = bcElemclassitem.Id }, bcElemclassitem);
        }

        // DELETE: api/BcElemclassitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemclassitem>> DeleteBcElemclassitem(long id)
        {
            var bcElemclassitem = await _context.BcElemclassitem.FindAsync(id);
            if (bcElemclassitem == null)
            {
                return NotFound();
            }

            _context.BcElemclassitem.Remove(bcElemclassitem);
            await _context.SaveChangesAsync();

            return bcElemclassitem;
        }

        private bool BcElemclassitemExists(long id)
        {
            return _context.BcElemclassitem.Any(e => e.Id == id);
        }
    }
}
