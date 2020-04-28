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
    public class BcElemmaterialController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcElemmaterialController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcElemmaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemmaterial>>> GetBcElemmaterial()
        {
            return await _context.BcElemmaterial.ToListAsync();
        }

        // GET: api/BcElemmaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemmaterial>> GetBcElemmaterial(long id)
        {
            var bcElemmaterial = await _context.BcElemmaterial.FindAsync(id);

            if (bcElemmaterial == null)
            {
                return NotFound();
            }

            return bcElemmaterial;
        }

        // PUT: api/BcElemmaterial/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemmaterial(long id, BcElemmaterial bcElemmaterial)
        {
            if (id != bcElemmaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemmaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElemmaterialExists(id))
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

        // POST: api/BcElemmaterial
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElemmaterial>> PostBcElemmaterial(BcElemmaterial bcElemmaterial)
        {
            _context.BcElemmaterial.Add(bcElemmaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemmaterial", new { id = bcElemmaterial.Id }, bcElemmaterial);
        }

        // DELETE: api/BcElemmaterial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemmaterial>> DeleteBcElemmaterial(long id)
        {
            var bcElemmaterial = await _context.BcElemmaterial.FindAsync(id);
            if (bcElemmaterial == null)
            {
                return NotFound();
            }

            _context.BcElemmaterial.Remove(bcElemmaterial);
            await _context.SaveChangesAsync();

            return bcElemmaterial;
        }

        private bool BcElemmaterialExists(long id)
        {
            return _context.BcElemmaterial.Any(e => e.Id == id);
        }
    }
}
