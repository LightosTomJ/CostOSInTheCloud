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
    public class TakeoffareaController : ControllerBase
    {
        private readonly LocalContext _context;

        public TakeoffareaController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Takeoffarea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakeOffArea>>> GetTakeoffarea()
        {
            return await _context.TakeOffArea.ToListAsync();
        }

        // GET: api/Takeoffarea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakeOffArea>> GetTakeoffarea(long id)
        {
            var takeoffarea = await _context.TakeOffArea.FindAsync(id);

            if (takeoffarea == null)
            {
                return NotFound();
            }

            return takeoffarea;
        }

        // PUT: api/Takeoffarea/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeoffarea(long id, TakeOffArea takeoffarea)
        {
            if (id != takeoffarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(takeoffarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeoffareaExists(id))
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

        // POST: api/Takeoffarea
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TakeOffArea>> PostTakeoffarea(TakeOffArea takeoffarea)
        {
            _context.TakeOffArea.Add(takeoffarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeoffarea", new { id = takeoffarea.Id }, takeoffarea);
        }

        // DELETE: api/Takeoffarea/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TakeOffArea>> DeleteTakeoffarea(long id)
        {
            var takeoffarea = await _context.TakeOffArea.FindAsync(id);
            if (takeoffarea == null)
            {
                return NotFound();
            }

            _context.TakeOffArea.Remove(takeoffarea);
            await _context.SaveChangesAsync();

            return takeoffarea;
        }

        private bool TakeoffareaExists(long id)
        {
            return _context.TakeOffArea.Any(e => e.Id == id);
        }
    }
}
