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
    public class BcElemconnectionController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcElemconnectionController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcElemconnection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemConnection>>> GetBcElemconnection()
        {
            return await _context.BcElemConnection.ToListAsync();
        }

        // GET: api/BcElemconnection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemConnection>> GetBcElemconnection(long id)
        {
            var bcElemconnection = await _context.BcElemConnection.FindAsync(id);

            if (bcElemconnection == null)
            {
                return NotFound();
            }

            return bcElemconnection;
        }

        // PUT: api/BcElemconnection/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemconnection(long id, BcElemConnection bcElemconnection)
        {
            if (id != bcElemconnection.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemconnection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElemconnectionExists(id))
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

        // POST: api/BcElemconnection
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElemConnection>> PostBcElemconnection(BcElemConnection bcElemconnection)
        {
            _context.BcElemConnection.Add(bcElemconnection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemconnection", new { id = bcElemconnection.Id }, bcElemconnection);
        }

        // DELETE: api/BcElemconnection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemConnection>> DeleteBcElemconnection(long id)
        {
            var bcElemconnection = await _context.BcElemConnection.FindAsync(id);
            if (bcElemconnection == null)
            {
                return NotFound();
            }

            _context.BcElemConnection.Remove(bcElemconnection);
            await _context.SaveChangesAsync();

            return bcElemconnection;
        }

        private bool BcElemconnectionExists(long id)
        {
            return _context.BcElemConnection.Any(e => e.Id == id);
        }
    }
}
