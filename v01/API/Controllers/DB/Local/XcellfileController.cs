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
    public class XcellfileController : ControllerBase
    {
        private readonly localContext _context;

        public XcellfileController(localContext context)
        {
            _context = context;
        }

        // GET: api/Xcellfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Xcellfile>>> GetXcellfile()
        {
            return await _context.Xcellfile.ToListAsync();
        }

        // GET: api/Xcellfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Xcellfile>> GetXcellfile(long id)
        {
            var xcellfile = await _context.Xcellfile.FindAsync(id);

            if (xcellfile == null)
            {
                return NotFound();
            }

            return xcellfile;
        }

        // PUT: api/Xcellfile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXcellfile(long id, Xcellfile xcellfile)
        {
            if (id != xcellfile.Xcellid)
            {
                return BadRequest();
            }

            _context.Entry(xcellfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XcellfileExists(id))
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

        // POST: api/Xcellfile
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Xcellfile>> PostXcellfile(Xcellfile xcellfile)
        {
            _context.Xcellfile.Add(xcellfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXcellfile", new { id = xcellfile.Xcellid }, xcellfile);
        }

        // DELETE: api/Xcellfile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Xcellfile>> DeleteXcellfile(long id)
        {
            var xcellfile = await _context.Xcellfile.FindAsync(id);
            if (xcellfile == null)
            {
                return NotFound();
            }

            _context.Xcellfile.Remove(xcellfile);
            await _context.SaveChangesAsync();

            return xcellfile;
        }

        private bool XcellfileExists(long id)
        {
            return _context.Xcellfile.Any(e => e.Xcellid == id);
        }
    }
}
