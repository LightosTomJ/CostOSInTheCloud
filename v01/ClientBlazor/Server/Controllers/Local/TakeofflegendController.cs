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
    public class TakeofflegendController : ControllerBase
    {
        private readonly localContext _context;

        public TakeofflegendController(localContext context)
        {
            _context = context;
        }

        // GET: api/Takeofflegend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Takeofflegend>>> GetTakeofflegend()
        {
            return await _context.Takeofflegend.ToListAsync();
        }

        // GET: api/Takeofflegend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Takeofflegend>> GetTakeofflegend(long id)
        {
            var takeofflegend = await _context.Takeofflegend.FindAsync(id);

            if (takeofflegend == null)
            {
                return NotFound();
            }

            return takeofflegend;
        }

        // PUT: api/Takeofflegend/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeofflegend(long id, Takeofflegend takeofflegend)
        {
            if (id != takeofflegend.Id)
            {
                return BadRequest();
            }

            _context.Entry(takeofflegend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeofflegendExists(id))
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

        // POST: api/Takeofflegend
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Takeofflegend>> PostTakeofflegend(Takeofflegend takeofflegend)
        {
            _context.Takeofflegend.Add(takeofflegend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeofflegend", new { id = takeofflegend.Id }, takeofflegend);
        }

        // DELETE: api/Takeofflegend/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Takeofflegend>> DeleteTakeofflegend(long id)
        {
            var takeofflegend = await _context.Takeofflegend.FindAsync(id);
            if (takeofflegend == null)
            {
                return NotFound();
            }

            _context.Takeofflegend.Remove(takeofflegend);
            await _context.SaveChangesAsync();

            return takeofflegend;
        }

        private bool TakeofflegendExists(long id)
        {
            return _context.Takeofflegend.Any(e => e.Id == id);
        }
    }
}
