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
    public class BcClassitemController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcClassitemController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcClassitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcClassItem>>> GetBcClassitem()
        {
            return await _context.BcClassItem.ToListAsync();
        }

        // GET: api/BcClassitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcClassItem>> GetBcClassitem(long id)
        {
            var bcClassitem = await _context.BcClassItem.FindAsync(id);

            if (bcClassitem == null)
            {
                return NotFound();
            }

            return bcClassitem;
        }

        // PUT: api/BcClassitem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcClassitem(long id, BcClassItem bcClassitem)
        {
            if (id != bcClassitem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcClassitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcClassitemExists(id))
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

        // POST: api/BcClassitem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcClassItem>> PostBcClassitem(BcClassItem bcClassitem)
        {
            _context.BcClassItem.Add(bcClassitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcClassitem", new { id = bcClassitem.Id }, bcClassitem);
        }

        // DELETE: api/BcClassitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcClassItem>> DeleteBcClassitem(long id)
        {
            var bcClassitem = await _context.BcClassItem.FindAsync(id);
            if (bcClassitem == null)
            {
                return NotFound();
            }

            _context.BcClassItem.Remove(bcClassitem);
            await _context.SaveChangesAsync();

            return bcClassitem;
        }

        private bool BcClassitemExists(long id)
        {
            return _context.BcClassItem.Any(e => e.Id == id);
        }
    }
}
