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
    public class WsrevisionController : ControllerBase
    {
        private readonly LocalContext _context;

        public WsrevisionController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Wsrevision
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WsRevision>>> GetWsrevision()
        {
            return await _context.WsRevision.ToListAsync();
        }

        // GET: api/Wsrevision/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WsRevision>> GetWsrevision(long id)
        {
            var wsrevision = await _context.WsRevision.FindAsync(id);

            if (wsrevision == null)
            {
                return NotFound();
            }

            return wsrevision;
        }

        // PUT: api/Wsrevision/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWsrevision(long id, WsRevision wsrevision)
        {
            if (id != wsrevision.Id)
            {
                return BadRequest();
            }

            _context.Entry(wsrevision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WsrevisionExists(id))
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

        // POST: api/Wsrevision
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WsRevision>> PostWsrevision(WsRevision wsrevision)
        {
            _context.WsRevision.Add(wsrevision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWsrevision", new { id = wsrevision.Id }, wsrevision);
        }

        // DELETE: api/Wsrevision/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WsRevision>> DeleteWsrevision(long id)
        {
            var wsrevision = await _context.WsRevision.FindAsync(id);
            if (wsrevision == null)
            {
                return NotFound();
            }

            _context.WsRevision.Remove(wsrevision);
            await _context.SaveChangesAsync();

            return wsrevision;
        }

        private bool WsrevisionExists(long id)
        {
            return _context.WsRevision.Any(e => e.Id == id);
        }
    }
}
