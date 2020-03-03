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
    public class BcClassitemController : ControllerBase
    {
        private readonly localContext _context;

        public BcClassitemController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcClassitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcClassitem>>> GetBcClassitem()
        {
            return await _context.BcClassitem.ToListAsync();
        }

        // GET: api/BcClassitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcClassitem>> GetBcClassitem(long id)
        {
            var bcClassitem = await _context.BcClassitem.FindAsync(id);

            if (bcClassitem == null)
            {
                return NotFound();
            }

            return bcClassitem;
        }

        // PUT: api/BcClassitem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcClassitem(long id, BcClassitem bcClassitem)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcClassitem>> PostBcClassitem(BcClassitem bcClassitem)
        {
            _context.BcClassitem.Add(bcClassitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcClassitem", new { id = bcClassitem.Id }, bcClassitem);
        }

        // DELETE: api/BcClassitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcClassitem>> DeleteBcClassitem(long id)
        {
            var bcClassitem = await _context.BcClassitem.FindAsync(id);
            if (bcClassitem == null)
            {
                return NotFound();
            }

            _context.BcClassitem.Remove(bcClassitem);
            await _context.SaveChangesAsync();

            return bcClassitem;
        }

        private bool BcClassitemExists(long id)
        {
            return _context.BcClassitem.Any(e => e.Id == id);
        }
    }
}
