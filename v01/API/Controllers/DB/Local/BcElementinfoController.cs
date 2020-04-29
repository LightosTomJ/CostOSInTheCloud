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
    public class BcElementinfoController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcElementinfoController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcElementinfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElementInfo>>> GetBcElementinfo()
        {
            return await _context.BcElementInfo.ToListAsync();
        }

        // GET: api/BcElementinfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElementInfo>> GetBcElementinfo(long id)
        {
            var bcElementinfo = await _context.BcElementInfo.FindAsync(id);

            if (bcElementinfo == null)
            {
                return NotFound();
            }

            return bcElementinfo;
        }

        // PUT: api/BcElementinfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElementinfo(long id, BcElementInfo bcElementinfo)
        {
            if (id != bcElementinfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcElementinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcElementinfoExists(id))
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

        // POST: api/BcElementinfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcElementInfo>> PostBcElementinfo(BcElementInfo bcElementinfo)
        {
            _context.BcElementInfo.Add(bcElementinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElementinfo", new { id = bcElementinfo.Id }, bcElementinfo);
        }

        // DELETE: api/BcElementinfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElementInfo>> DeleteBcElementinfo(long id)
        {
            var bcElementinfo = await _context.BcElementInfo.FindAsync(id);
            if (bcElementinfo == null)
            {
                return NotFound();
            }

            _context.BcElementInfo.Remove(bcElementinfo);
            await _context.SaveChangesAsync();

            return bcElementinfo;
        }

        private bool BcElementinfoExists(long id)
        {
            return _context.BcElementInfo.Any(e => e.Id == id);
        }
    }
}
