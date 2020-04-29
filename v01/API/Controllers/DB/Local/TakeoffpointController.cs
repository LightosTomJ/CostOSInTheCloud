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
    public class TakeoffpointController : ControllerBase
    {
        private readonly LocalContext _context;

        public TakeoffpointController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakeOffPoint>>> GetTakeoffpoint()
        {
            return await _context.TakeOffPoint.ToListAsync();
        }

        // GET: api/Takeoffpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakeOffPoint>> GetTakeoffpoint(long id)
        {
            var takeoffpoint = await _context.TakeOffPoint.FindAsync(id);

            if (takeoffpoint == null)
            {
                return NotFound();
            }

            return takeoffpoint;
        }

        // PUT: api/Takeoffpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffpoint(long id, TakeOffPoint takeoffpoint)
        {
            if (id != takeoffpoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(takeoffpoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeoffpointExists(id))
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

        // POST: api/Takeoffpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TakeOffPoint>> PostTakeoffpoint(TakeOffPoint takeoffpoint)
        {
            _context.TakeOffPoint.Add(takeoffpoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffpoint", new { id = takeoffpoint.Id }, takeoffpoint);
        }

        // DELETE: api/Takeoffpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TakeOffPoint>> DeleteTakeoffpoint(long id)
        {
            var takeoffpoint = await _context.TakeOffPoint.FindAsync(id);
            if (takeoffpoint == null)
            {
                return NotFound();
            }

            _context.TakeOffPoint.Remove(takeoffpoint);
            await _context.SaveChangesAsync();

            return takeoffpoint;
        }

        private bool TakeoffpointExists(long id)
        {
            return _context.TakeOffPoint.Any(e => e.Id == id);
        }
    }
}
