using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablePartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public ConsumablePartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/ConsumablePartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumablePartial>>> GetConsumablePartial()
        {
            return await _context.ConsumablePartial.ToListAsync();
        }

        // GET: api/ConsumablePartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumablePartial>> GetConsumablePartial(int id)
        {
            var consumablePartial = await _context.ConsumablePartial.FindAsync(id);

            if (consumablePartial == null)
            {
                return NotFound();
            }

            return consumablePartial;
        }

        // PUT: api/ConsumablePartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumablePartial(int id, ConsumablePartial consumablePartial)
        {
            if (id != consumablePartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumablePartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumablePartialExists(id))
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

        // POST: api/ConsumablePartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ConsumablePartial>> PostConsumablePartial(ConsumablePartial consumablePartial)
        {
            _context.ConsumablePartial.Add(consumablePartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsumablePartialExists(consumablePartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsumablePartial", new { id = consumablePartial.Id }, consumablePartial);
        }

        // DELETE: api/ConsumablePartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsumablePartial>> DeleteConsumablePartial(int id)
        {
            var consumablePartial = await _context.ConsumablePartial.FindAsync(id);
            if (consumablePartial == null)
            {
                return NotFound();
            }

            _context.ConsumablePartial.Remove(consumablePartial);
            await _context.SaveChangesAsync();

            return consumablePartial;
        }

        private bool ConsumablePartialExists(int id)
        {
            return _context.ConsumablePartial.Any(e => e.Id == id);
        }
    }
}
