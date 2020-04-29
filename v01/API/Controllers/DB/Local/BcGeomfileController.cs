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
    public class BcGeomfileController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcGeomfileController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcGeomfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGeomFile>>> GetBcGeomfile()
        {
            return await _context.BcGeomFile.ToListAsync();
        }

        // GET: api/BcGeomfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGeomFile>> GetBcGeomfile(long id)
        {
            var bcGeomfile = await _context.BcGeomFile.FindAsync(id);

            if (bcGeomfile == null)
            {
                return NotFound();
            }

            return bcGeomfile;
        }

        // PUT: api/BcGeomfile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGeomfile(long id, BcGeomFile bcGeomfile)
        {
            if (id != bcGeomfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcGeomfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcGeomfileExists(id))
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

        // POST: api/BcGeomfile
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcGeomFile>> PostBcGeomfile(BcGeomFile bcGeomfile)
        {
            _context.BcGeomFile.Add(bcGeomfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGeomfile", new { id = bcGeomfile.Id }, bcGeomfile);
        }

        // DELETE: api/BcGeomfile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGeomFile>> DeleteBcGeomfile(long id)
        {
            var bcGeomfile = await _context.BcGeomFile.FindAsync(id);
            if (bcGeomfile == null)
            {
                return NotFound();
            }

            _context.BcGeomFile.Remove(bcGeomfile);
            await _context.SaveChangesAsync();

            return bcGeomfile;
        }

        private bool BcGeomfileExists(long id)
        {
            return _context.BcGeomFile.Any(e => e.Id == id);
        }
    }
}
