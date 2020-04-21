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
    public class TakeoffconController : ControllerBase
    {
        private readonly localContext _context;

        public TakeoffconController(localContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffcon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Takeoffcon>>> GetTakeoffcon()
        {
            return await _context.Takeoffcon.ToListAsync();
        }

        // GET: api/Takeoffcon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Takeoffcon>> GetTakeoffcon(long id)
        {
            var takeoffcon = await _context.Takeoffcon.FindAsync(id);

            if (takeoffcon == null)
            {
                return NotFound();
            }

            return takeoffcon;
        }

        // PUT: api/Takeoffcon/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffcon(long id, Takeoffcon takeoffcon)
        {
            if (id != takeoffcon.Id)
            {
                return BadRequest();
            }

            _context.Entry(takeoffcon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeoffconExists(id))
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

        // POST: api/Takeoffcon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Takeoffcon>> PostTakeoffcon(Takeoffcon takeoffcon)
        {
            _context.Takeoffcon.Add(takeoffcon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffcon", new { id = takeoffcon.Id }, takeoffcon);
        }

        // DELETE: api/Takeoffcon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Takeoffcon>> DeleteTakeoffcon(long id)
        {
            var takeoffcon = await _context.Takeoffcon.FindAsync(id);
            if (takeoffcon == null)
            {
                return NotFound();
            }

            _context.Takeoffcon.Remove(takeoffcon);
            await _context.SaveChangesAsync();

            return takeoffcon;
        }

        private bool TakeoffconExists(long id)
        {
            return _context.Takeoffcon.Any(e => e.Id == id);
        }
    }
}