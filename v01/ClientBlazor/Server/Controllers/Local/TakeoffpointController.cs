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
    public class TakeoffpointController : ControllerBase
    {
        private readonly localContext _context;

        public TakeoffpointController(localContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Takeoffpoint>>> GetTakeoffpoint()
        {
            return await _context.Takeoffpoint.ToListAsync();
        }

        // GET: api/Takeoffpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Takeoffpoint>> GetTakeoffpoint(long id)
        {
            var takeoffpoint = await _context.Takeoffpoint.FindAsync(id);

            if (takeoffpoint == null)
            {
                return NotFound();
            }

            return takeoffpoint;
        }

        // PUT: api/Takeoffpoint/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffpoint(long id, Takeoffpoint takeoffpoint)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Takeoffpoint>> PostTakeoffpoint(Takeoffpoint takeoffpoint)
        {
            _context.Takeoffpoint.Add(takeoffpoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffpoint", new { id = takeoffpoint.Id }, takeoffpoint);
        }

        // DELETE: api/Takeoffpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Takeoffpoint>> DeleteTakeoffpoint(long id)
        {
            var takeoffpoint = await _context.Takeoffpoint.FindAsync(id);
            if (takeoffpoint == null)
            {
                return NotFound();
            }

            _context.Takeoffpoint.Remove(takeoffpoint);
            await _context.SaveChangesAsync();

            return takeoffpoint;
        }

        private bool TakeoffpointExists(long id)
        {
            return _context.Takeoffpoint.Any(e => e.Id == id);
        }
    }
}
