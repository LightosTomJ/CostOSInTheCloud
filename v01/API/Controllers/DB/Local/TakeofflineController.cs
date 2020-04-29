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
    public class TakeofflineController : ControllerBase
    {
        private readonly LocalContext _context;

        public TakeofflineController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakeOffLine>>> GetTakeoffline()
        {
            return await _context.TakeOffLine.ToListAsync();
        }

        // GET: api/Takeoffline/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakeOffLine>> GetTakeoffline(long id)
        {
            var takeoffline = await _context.TakeOffLine.FindAsync(id);

            if (takeoffline == null)
            {
                return NotFound();
            }

            return takeoffline;
        }

        // PUT: api/Takeoffline/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffline(long id, TakeOffLine takeoffline)
        {
            if (id != takeoffline.Id)
            {
                return BadRequest();
            }

            _context.Entry(takeoffline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeofflineExists(id))
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

        // POST: api/Takeoffline
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TakeOffLine>> PostTakeoffline(TakeOffLine takeoffline)
        {
            _context.TakeOffLine.Add(takeoffline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffline", new { id = takeoffline.Id }, takeoffline);
        }

        // DELETE: api/Takeoffline/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TakeOffLine>> DeleteTakeoffline(long id)
        {
            var takeoffline = await _context.TakeOffLine.FindAsync(id);
            if (takeoffline == null)
            {
                return NotFound();
            }

            _context.TakeOffLine.Remove(takeoffline);
            await _context.SaveChangesAsync();

            return takeoffline;
        }

        private bool TakeofflineExists(long id)
        {
            return _context.TakeOffLine.Any(e => e.Id == id);
        }
    }
}
