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
    public class BcElemconnectionController : ControllerBase
    {
        private readonly localContext _context;

        public BcElemconnectionController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElemconnection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElemconnection>>> GetBcElemconnection()
        {
            return await _context.BcElemconnection.ToListAsync();
        }

        // GET: api/BcElemconnection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElemconnection>> GetBcElemconnection(long id)
        {
            var bcElemconnection = await _context.BcElemconnection.FindAsync(id);

            if (bcElemconnection == null)
            {
                return NotFound();
            }

            return bcElemconnection;
        }

        // PUT: api/BcElemconnection/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElemconnection(long id, BcElemconnection bcElemconnection)
        {
            if (id != bcElemconnection.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElemconnection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElemconnectionExists(id))
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

        // POST: api/BcElemconnection
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcElemconnection>> PostBcElemconnection(BcElemconnection bcElemconnection)
        {
            _context.BcElemconnection.Add(bcElemconnection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElemconnection", new { id = bcElemconnection.Id }, bcElemconnection);
        }

        // DELETE: api/BcElemconnection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElemconnection>> DeleteBcElemconnection(long id)
        {
            var bcElemconnection = await _context.BcElemconnection.FindAsync(id);
            if (bcElemconnection == null)
            {
                return NotFound();
            }

            _context.BcElemconnection.Remove(bcElemconnection);
            await _context.SaveChangesAsync();

            return bcElemconnection;
        }

        private bool BcElemconnectionExists(long id)
        {
            return _context.BcElemconnection.Any(e => e.Id == id);
        }
    }
}
