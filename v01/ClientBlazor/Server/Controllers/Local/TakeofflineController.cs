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
    public class TakeofflineController : ControllerBase
    {
        private readonly localContext _context;

        public TakeofflineController(localContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Takeoffline>>> GetTakeoffline()
        {
            return await _context.Takeoffline.ToListAsync();
        }

        // GET: api/Takeoffline/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Takeoffline>> GetTakeoffline(long id)
        {
            var takeoffline = await _context.Takeoffline.FindAsync(id);

            if (takeoffline == null)
            {
                return NotFound();
            }

            return takeoffline;
        }

        // PUT: api/Takeoffline/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffline(long id, Takeoffline takeoffline)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Takeoffline>> PostTakeoffline(Takeoffline takeoffline)
        {
            _context.Takeoffline.Add(takeoffline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffline", new { id = takeoffline.Id }, takeoffline);
        }

        // DELETE: api/Takeoffline/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Takeoffline>> DeleteTakeoffline(long id)
        {
            var takeoffline = await _context.Takeoffline.FindAsync(id);
            if (takeoffline == null)
            {
                return NotFound();
            }

            _context.Takeoffline.Remove(takeoffline);
            await _context.SaveChangesAsync();

            return takeoffline;
        }

        private bool TakeofflineExists(long id)
        {
            return _context.Takeoffline.Any(e => e.Id == id);
        }
    }
}
