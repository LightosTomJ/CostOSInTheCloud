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
    public class ConsumableController : ControllerBase
    {
        private readonly LocalContext _context;

        public ConsumableController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Consumable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumable>>> GetConsumable()
        {
            return await _context.Consumable.ToListAsync();
        }

        // GET: api/Consumable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumable>> GetConsumable(long id)
        {
            var consumable = await _context.Consumable.FindAsync(id);

            if (consumable == null)
            {
                return NotFound();
            }

            return consumable;
        }

        // PUT: api/Consumable/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumable(long id, Consumable consumable)
        {
            if (id != consumable.Consumableid)
            {
                return BadRequest();
            }

            _context.Entry(consumable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumableExists(id))
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

        // POST: api/Consumable
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Consumable>> PostConsumable(Consumable consumable)
        {
            _context.Consumable.Add(consumable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumable", new { id = consumable.Consumableid }, consumable);
        }

        // DELETE: api/Consumable/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consumable>> DeleteConsumable(long id)
        {
            var consumable = await _context.Consumable.FindAsync(id);
            if (consumable == null)
            {
                return NotFound();
            }

            _context.Consumable.Remove(consumable);
            await _context.SaveChangesAsync();

            return consumable;
        }

        private bool ConsumableExists(long id)
        {
            return _context.Consumable.Any(e => e.Consumableid == id);
        }
    }
}
