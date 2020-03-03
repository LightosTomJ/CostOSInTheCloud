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
    public class BcGpuserverController : ControllerBase
    {
        private readonly localContext _context;

        public BcGpuserverController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcGpuserver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGpuserver>>> GetBcGpuserver()
        {
            return await _context.BcGpuserver.ToListAsync();
        }

        // GET: api/BcGpuserver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGpuserver>> GetBcGpuserver(long id)
        {
            var bcGpuserver = await _context.BcGpuserver.FindAsync(id);

            if (bcGpuserver == null)
            {
                return NotFound();
            }

            return bcGpuserver;
        }

        // PUT: api/BcGpuserver/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGpuserver(long id, BcGpuserver bcGpuserver)
        {
            if (id != bcGpuserver.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcGpuserver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcGpuserverExists(id))
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

        // POST: api/BcGpuserver
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcGpuserver>> PostBcGpuserver(BcGpuserver bcGpuserver)
        {
            _context.BcGpuserver.Add(bcGpuserver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGpuserver", new { id = bcGpuserver.Id }, bcGpuserver);
        }

        // DELETE: api/BcGpuserver/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGpuserver>> DeleteBcGpuserver(long id)
        {
            var bcGpuserver = await _context.BcGpuserver.FindAsync(id);
            if (bcGpuserver == null)
            {
                return NotFound();
            }

            _context.BcGpuserver.Remove(bcGpuserver);
            await _context.SaveChangesAsync();

            return bcGpuserver;
        }

        private bool BcGpuserverExists(long id)
        {
            return _context.BcGpuserver.Any(e => e.Id == id);
        }
    }
}
