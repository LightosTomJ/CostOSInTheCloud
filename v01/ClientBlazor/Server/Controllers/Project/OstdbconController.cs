using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class OstdbconController : ControllerBase
    {
        private readonly projectContext _context;

        public OstdbconController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Ostdbcon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ostdbcon>>> GetOstdbcon()
        {
            return await _context.Ostdbcon.ToListAsync();
        }

        // GET: api/Ostdbcon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ostdbcon>> GetOstdbcon(long id)
        {
            var ostdbcon = await _context.Ostdbcon.FindAsync(id);

            if (ostdbcon == null)
            {
                return NotFound();
            }

            return ostdbcon;
        }

        // PUT: api/Ostdbcon/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOstdbcon(long id, Ostdbcon ostdbcon)
        {
            if (id != ostdbcon.Ostconid)
            {
                return BadRequest();
            }

            _context.Entry(ostdbcon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OstdbconExists(id))
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

        // POST: api/Ostdbcon
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ostdbcon>> PostOstdbcon(Ostdbcon ostdbcon)
        {
            _context.Ostdbcon.Add(ostdbcon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOstdbcon", new { id = ostdbcon.Ostconid }, ostdbcon);
        }

        // DELETE: api/Ostdbcon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ostdbcon>> DeleteOstdbcon(long id)
        {
            var ostdbcon = await _context.Ostdbcon.FindAsync(id);
            if (ostdbcon == null)
            {
                return NotFound();
            }

            _context.Ostdbcon.Remove(ostdbcon);
            await _context.SaveChangesAsync();

            return ostdbcon;
        }

        private bool OstdbconExists(long id)
        {
            return _context.Ostdbcon.Any(e => e.Ostconid == id);
        }
    }
}
