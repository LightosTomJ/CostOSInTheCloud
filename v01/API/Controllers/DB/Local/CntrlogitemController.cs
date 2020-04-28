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
    public class CntrlogitemController : ControllerBase
    {
        private readonly LocalContext _context;

        public CntrlogitemController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Cntrlogitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cntrlogitem>>> GetCntrlogitem()
        {
            return await _context.Cntrlogitem.ToListAsync();
        }

        // GET: api/Cntrlogitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cntrlogitem>> GetCntrlogitem(long id)
        {
            var cntrlogitem = await _context.Cntrlogitem.FindAsync(id);

            if (cntrlogitem == null)
            {
                return NotFound();
            }

            return cntrlogitem;
        }

        // PUT: api/Cntrlogitem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCntrlogitem(long id, Cntrlogitem cntrlogitem)
        {
            if (id != cntrlogitem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cntrlogitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CntrlogitemExists(id))
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

        // POST: api/Cntrlogitem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cntrlogitem>> PostCntrlogitem(Cntrlogitem cntrlogitem)
        {
            _context.Cntrlogitem.Add(cntrlogitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCntrlogitem", new { id = cntrlogitem.Id }, cntrlogitem);
        }

        // DELETE: api/Cntrlogitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cntrlogitem>> DeleteCntrlogitem(long id)
        {
            var cntrlogitem = await _context.Cntrlogitem.FindAsync(id);
            if (cntrlogitem == null)
            {
                return NotFound();
            }

            _context.Cntrlogitem.Remove(cntrlogitem);
            await _context.SaveChangesAsync();

            return cntrlogitem;
        }

        private bool CntrlogitemExists(long id)
        {
            return _context.Cntrlogitem.Any(e => e.Id == id);
        }
    }
}
