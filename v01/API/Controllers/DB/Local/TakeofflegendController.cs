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
    public class TakeofflegendController : ControllerBase
    {
        private readonly LocalContext _context;

        public TakeofflegendController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Takeofflegend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakeOffLegend>>> GetTakeofflegend()
        {
            return await _context.TakeOffLegend.ToListAsync();
        }

        // GET: api/Takeofflegend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakeOffLegend>> GetTakeofflegend(long id)
        {
            var takeofflegend = await _context.TakeOffLegend.FindAsync(id);

            if (takeofflegend == null)
            {
                return NotFound();
            }

            return takeofflegend;
        }

        // PUT: api/Takeofflegend/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeofflegend(long id, TakeOffLegend takeofflegend)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TakeOffLegend>> PostTakeofflegend(TakeOffLegend takeofflegend)
        {
            _context.TakeOffLegend.Add(takeofflegend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeofflegend", new { id = takeofflegend.Id }, takeofflegend);
        }

        // DELETE: api/Takeofflegend/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TakeOffLegend>> DeleteTakeofflegend(long id)
        {
            var takeofflegend = await _context.TakeOffLegend.FindAsync(id);
            if (takeofflegend == null)
            {
                return NotFound();
            }

            _context.TakeOffLegend.Remove(takeofflegend);
            await _context.SaveChangesAsync();

            return takeofflegend;
        }

        private bool TakeofflegendExists(long id)
        {
            return _context.TakeOffLegend.Any(e => e.Id == id);
        }
    }
}
