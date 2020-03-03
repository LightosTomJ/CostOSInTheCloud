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
    public class ParaminputController : ControllerBase
    {
        private readonly localContext _context;

        public ParaminputController(localContext context)
        {
            _context = context;
        }

        // GET: api/Paraminput
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paraminput>>> GetParaminput()
        {
            return await _context.Paraminput.ToListAsync();
        }

        // GET: api/Paraminput/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paraminput>> GetParaminput(long id)
        {
            var paraminput = await _context.Paraminput.FindAsync(id);

            if (paraminput == null)
            {
                return NotFound();
            }

            return paraminput;
        }

        // PUT: api/Paraminput/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParaminput(long id, Paraminput paraminput)
        {
            if (id != paraminput.Paraminputid)
            {
                return BadRequest();
            }

            _context.Entry(paraminput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParaminputExists(id))
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

        // POST: api/Paraminput
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Paraminput>> PostParaminput(Paraminput paraminput)
        {
            _context.Paraminput.Add(paraminput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParaminput", new { id = paraminput.Paraminputid }, paraminput);
        }

        // DELETE: api/Paraminput/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paraminput>> DeleteParaminput(long id)
        {
            var paraminput = await _context.Paraminput.FindAsync(id);
            if (paraminput == null)
            {
                return NotFound();
            }

            _context.Paraminput.Remove(paraminput);
            await _context.SaveChangesAsync();

            return paraminput;
        }

        private bool ParaminputExists(long id)
        {
            return _context.Paraminput.Any(e => e.Paraminputid == id);
        }
    }
}
