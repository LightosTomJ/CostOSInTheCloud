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
    public class BcElementController : ControllerBase
    {
        private readonly localContext _context;

        public BcElementController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElement>>> GetBcElement()
        {
            return await _context.BcElement.ToListAsync();
        }

        // GET: api/BcElement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElement>> GetBcElement(long id)
        {
            var bcElement = await _context.BcElement.FindAsync(id);

            if (bcElement == null)
            {
                return NotFound();
            }

            return bcElement;
        }

        // PUT: api/BcElement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElement(long id, BcElement bcElement)
        {
            if (id != bcElement.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElementExists(id))
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

        // POST: api/BcElement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElement>> PostBcElement(BcElement bcElement)
        {
            _context.BcElement.Add(bcElement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElement", new { id = bcElement.Id }, bcElement);
        }

        // DELETE: api/BcElement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElement>> DeleteBcElement(long id)
        {
            var bcElement = await _context.BcElement.FindAsync(id);
            if (bcElement == null)
            {
                return NotFound();
            }

            _context.BcElement.Remove(bcElement);
            await _context.SaveChangesAsync();

            return bcElement;
        }

        private bool BcElementExists(long id)
        {
            return _context.BcElement.Any(e => e.Id == id);
        }
    }
}
