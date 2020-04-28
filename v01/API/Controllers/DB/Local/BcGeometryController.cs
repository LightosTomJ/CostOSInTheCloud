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
    public class BcGeometryController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcGeometryController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcGeometry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGeometry>>> GetBcGeometry()
        {
            return await _context.BcGeometry.ToListAsync();
        }

        // GET: api/BcGeometry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGeometry>> GetBcGeometry(long id)
        {
            var bcGeometry = await _context.BcGeometry.FindAsync(id);

            if (bcGeometry == null)
            {
                return NotFound();
            }

            return bcGeometry;
        }

        // PUT: api/BcGeometry/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGeometry(long id, BcGeometry bcGeometry)
        {
            if (id != bcGeometry.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcGeometry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcGeometryExists(id))
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

        // POST: api/BcGeometry
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcGeometry>> PostBcGeometry(BcGeometry bcGeometry)
        {
            _context.BcGeometry.Add(bcGeometry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGeometry", new { id = bcGeometry.Id }, bcGeometry);
        }

        // DELETE: api/BcGeometry/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGeometry>> DeleteBcGeometry(long id)
        {
            var bcGeometry = await _context.BcGeometry.FindAsync(id);
            if (bcGeometry == null)
            {
                return NotFound();
            }

            _context.BcGeometry.Remove(bcGeometry);
            await _context.SaveChangesAsync();

            return bcGeometry;
        }

        private bool BcGeometryExists(long id)
        {
            return _context.BcGeometry.Any(e => e.Id == id);
        }
    }
}
