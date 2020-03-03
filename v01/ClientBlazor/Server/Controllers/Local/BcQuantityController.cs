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
    public class BcQuantityController : ControllerBase
    {
        private readonly localContext _context;

        public BcQuantityController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcQuantity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcQuantity>>> GetBcQuantity()
        {
            return await _context.BcQuantity.ToListAsync();
        }

        // GET: api/BcQuantity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcQuantity>> GetBcQuantity(long id)
        {
            var bcQuantity = await _context.BcQuantity.FindAsync(id);

            if (bcQuantity == null)
            {
                return NotFound();
            }

            return bcQuantity;
        }

        // PUT: api/BcQuantity/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcQuantity(long id, BcQuantity bcQuantity)
        {
            if (id != bcQuantity.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcQuantityExists(id))
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

        // POST: api/BcQuantity
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcQuantity>> PostBcQuantity(BcQuantity bcQuantity)
        {
            _context.BcQuantity.Add(bcQuantity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcQuantity", new { id = bcQuantity.Id }, bcQuantity);
        }

        // DELETE: api/BcQuantity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcQuantity>> DeleteBcQuantity(long id)
        {
            var bcQuantity = await _context.BcQuantity.FindAsync(id);
            if (bcQuantity == null)
            {
                return NotFound();
            }

            _context.BcQuantity.Remove(bcQuantity);
            await _context.SaveChangesAsync();

            return bcQuantity;
        }

        private bool BcQuantityExists(long id)
        {
            return _context.BcQuantity.Any(e => e.Id == id);
        }
    }
}
