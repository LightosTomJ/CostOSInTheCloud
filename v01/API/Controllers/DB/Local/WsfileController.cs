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
    public class WsfileController : ControllerBase
    {
        private readonly localContext _context;

        public WsfileController(localContext context)
        {
            _context = context;
        }

        // GET: api/Wsfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wsfile>>> GetWsfile()
        {
            return await _context.Wsfile.ToListAsync();
        }

        // GET: api/Wsfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wsfile>> GetWsfile(long id)
        {
            var wsfile = await _context.Wsfile.FindAsync(id);

            if (wsfile == null)
            {
                return NotFound();
            }

            return wsfile;
        }

        // PUT: api/Wsfile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWsfile(long id, Wsfile wsfile)
        {
            if (id != wsfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(wsfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WsfileExists(id))
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

        // POST: api/Wsfile
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wsfile>> PostWsfile(Wsfile wsfile)
        {
            _context.Wsfile.Add(wsfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWsfile", new { id = wsfile.Id }, wsfile);
        }

        // DELETE: api/Wsfile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wsfile>> DeleteWsfile(long id)
        {
            var wsfile = await _context.Wsfile.FindAsync(id);
            if (wsfile == null)
            {
                return NotFound();
            }

            _context.Wsfile.Remove(wsfile);
            await _context.SaveChangesAsync();

            return wsfile;
        }

        private bool WsfileExists(long id)
        {
            return _context.Wsfile.Any(e => e.Id == id);
        }
    }
}
