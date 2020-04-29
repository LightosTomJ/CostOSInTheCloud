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
    public class BcSpatialinfoController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcSpatialinfoController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcSpatialinfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcSpatialInfo>>> GetBcSpatialinfo()
        {
            return await _context.BcSpatialInfo.ToListAsync();
        }

        // GET: api/BcSpatialinfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcSpatialInfo>> GetBcSpatialinfo(long id)
        {
            var bcSpatialinfo = await _context.BcSpatialInfo.FindAsync(id);

            if (bcSpatialinfo == null)
            {
                return NotFound();
            }

            return bcSpatialinfo;
        }

        // PUT: api/BcSpatialinfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcSpatialinfo(long id, BcSpatialInfo bcSpatialinfo)
        {
            if (id != bcSpatialinfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcSpatialinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcSpatialinfoExists(id))
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

        // POST: api/BcSpatialinfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcSpatialInfo>> PostBcSpatialinfo(BcSpatialInfo bcSpatialinfo)
        {
            _context.BcSpatialInfo.Add(bcSpatialinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcSpatialinfo", new { id = bcSpatialinfo.Id }, bcSpatialinfo);
        }

        // DELETE: api/BcSpatialinfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcSpatialInfo>> DeleteBcSpatialinfo(long id)
        {
            var bcSpatialinfo = await _context.BcSpatialInfo.FindAsync(id);
            if (bcSpatialinfo == null)
            {
                return NotFound();
            }

            _context.BcSpatialInfo.Remove(bcSpatialinfo);
            await _context.SaveChangesAsync();

            return bcSpatialinfo;
        }

        private bool BcSpatialinfoExists(long id)
        {
            return _context.BcSpatialInfo.Any(e => e.Id == id);
        }
    }
}
