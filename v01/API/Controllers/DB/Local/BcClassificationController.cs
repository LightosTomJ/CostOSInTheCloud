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
    public class BcClassificationController : ControllerBase
    {
        private readonly localContext _context;

        public BcClassificationController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcClassification>>> GetBcClassification()
        {
            return await _context.BcClassification.ToListAsync();
        }

        // GET: api/BcClassification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcClassification>> GetBcClassification(long id)
        {
            var bcClassification = await _context.BcClassification.FindAsync(id);

            if (bcClassification == null)
            {
                return NotFound();
            }

            return bcClassification;
        }

        // PUT: api/BcClassification/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcClassification(long id, BcClassification bcClassification)
        {
            if (id != bcClassification.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcClassificationExists(id))
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

        // POST: api/BcClassification
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcClassification>> PostBcClassification(BcClassification bcClassification)
        {
            _context.BcClassification.Add(bcClassification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcClassification", new { id = bcClassification.Id }, bcClassification);
        }

        // DELETE: api/BcClassification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcClassification>> DeleteBcClassification(long id)
        {
            var bcClassification = await _context.BcClassification.FindAsync(id);
            if (bcClassification == null)
            {
                return NotFound();
            }

            _context.BcClassification.Remove(bcClassification);
            await _context.SaveChangesAsync();

            return bcClassification;
        }

        private bool BcClassificationExists(long id)
        {
            return _context.BcClassification.Any(e => e.Id == id);
        }
    }
}
