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
    public class BcGeomfileController : ControllerBase
    {
        private readonly localContext _context;

        public BcGeomfileController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcGeomfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGeomfile>>> GetBcGeomfile()
        {
            return await _context.BcGeomfile.ToListAsync();
        }

        // GET: api/BcGeomfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGeomfile>> GetBcGeomfile(long id)
        {
            var bcGeomfile = await _context.BcGeomfile.FindAsync(id);

            if (bcGeomfile == null)
            {
                return NotFound();
            }

            return bcGeomfile;
        }

        // PUT: api/BcGeomfile/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGeomfile(long id, BcGeomfile bcGeomfile)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcGeomfile>> PostBcGeomfile(BcGeomfile bcGeomfile)
        {
            _context.BcGeomfile.Add(bcGeomfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGeomfile", new { id = bcGeomfile.Id }, bcGeomfile);
        }

        // DELETE: api/BcGeomfile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGeomfile>> DeleteBcGeomfile(long id)
        {
            var bcGeomfile = await _context.BcGeomfile.FindAsync(id);
            if (bcGeomfile == null)
            {
                return NotFound();
            }

            _context.BcGeomfile.Remove(bcGeomfile);
            await _context.SaveChangesAsync();

            return bcGeomfile;
        }

        private bool BcGeomfileExists(long id)
        {
            return _context.BcGeomfile.Any(e => e.Id == id);
        }
    }
}
