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
        private readonly LocalContext _context;

        public WsfileController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Wsfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WsFile>>> GetWsfile()
        {
            return await _context.WsFile.ToListAsync();
        }

        // GET: api/Wsfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WsFile>> GetWsfile(long id)
        {
            var wsfile = await _context.WsFile.FindAsync(id);

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
        public async Task<IActionResult> PutWsfile(long id, WsFile wsfile)
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
        public async Task<ActionResult<WsFile>> PostWsfile(WsFile wsfile)
        {
            _context.WsFile.Add(wsfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWsfile", new { id = wsfile.Id }, wsfile);
        }

        // DELETE: api/Wsfile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WsFile>> DeleteWsfile(long id)
        {
            var wsfile = await _context.WsFile.FindAsync(id);
            if (wsfile == null)
            {
                return NotFound();
            }

            _context.WsFile.Remove(wsfile);
            await _context.SaveChangesAsync();

            return wsfile;
        }

        private bool WsfileExists(long id)
        {
            return _context.WsFile.Any(e => e.Id == id);
        }
    }
}
