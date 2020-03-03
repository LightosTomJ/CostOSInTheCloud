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
    public class WscolidentController : ControllerBase
    {
        private readonly localContext _context;

        public WscolidentController(localContext context)
        {
            _context = context;
        }

        // GET: api/Wscolident
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wscolident>>> GetWscolident()
        {
            return await _context.Wscolident.ToListAsync();
        }

        // GET: api/Wscolident/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wscolident>> GetWscolident(long id)
        {
            var wscolident = await _context.Wscolident.FindAsync(id);

            if (wscolident == null)
            {
                return NotFound();
            }

            return wscolident;
        }

        // PUT: api/Wscolident/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWscolident(long id, Wscolident wscolident)
        {
            if (id != wscolident.Id)
            {
                return BadRequest();
            }

            _context.Entry(wscolident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WscolidentExists(id))
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

        // POST: api/Wscolident
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Wscolident>> PostWscolident(Wscolident wscolident)
        {
            _context.Wscolident.Add(wscolident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWscolident", new { id = wscolident.Id }, wscolident);
        }

        // DELETE: api/Wscolident/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wscolident>> DeleteWscolident(long id)
        {
            var wscolident = await _context.Wscolident.FindAsync(id);
            if (wscolident == null)
            {
                return NotFound();
            }

            _context.Wscolident.Remove(wscolident);
            await _context.SaveChangesAsync();

            return wscolident;
        }

        private bool WscolidentExists(long id)
        {
            return _context.Wscolident.Any(e => e.Id == id);
        }
    }
}
