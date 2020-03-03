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
    public class BcElementinfoController : ControllerBase
    {
        private readonly localContext _context;

        public BcElementinfoController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcElementinfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcElementinfo>>> GetBcElementinfo()
        {
            return await _context.BcElementinfo.ToListAsync();
        }

        // GET: api/BcElementinfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcElementinfo>> GetBcElementinfo(long id)
        {
            var bcElementinfo = await _context.BcElementinfo.FindAsync(id);

            if (bcElementinfo == null)
            {
                return NotFound();
            }

            return bcElementinfo;
        }

        // PUT: api/BcElementinfo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcElementinfo(long id, BcElementinfo bcElementinfo)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcElementinfo>> PostBcElementinfo(BcElementinfo bcElementinfo)
        {
            _context.BcElementinfo.Add(bcElementinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcElementinfo", new { id = bcElementinfo.Id }, bcElementinfo);
        }

        // DELETE: api/BcElementinfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcElementinfo>> DeleteBcElementinfo(long id)
        {
            var bcElementinfo = await _context.BcElementinfo.FindAsync(id);
            if (bcElementinfo == null)
            {
                return NotFound();
            }

            _context.BcElementinfo.Remove(bcElementinfo);
            await _context.SaveChangesAsync();

            return bcElementinfo;
        }

        private bool BcElementinfoExists(long id)
        {
            return _context.BcElementinfo.Any(e => e.Id == id);
        }
    }
}