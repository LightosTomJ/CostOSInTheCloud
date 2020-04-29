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
    public class BcGpuserverController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcGpuserverController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcGpuserver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGPUServer>>> GetBcGpuserver()
        {
            return await _context.BcGPUServer.ToListAsync();
        }

        // GET: api/BcGpuserver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGPUServer>> GetBcGpuserver(long id)
        {
            var bcGpuserver = await _context.BcGPUServer.FindAsync(id);

            if (bcGpuserver == null)
            {
                return NotFound();
            }

            return bcGpuserver;
        }

        // PUT: api/BcGpuserver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGpuserver(long id, BcGPUServer bcGpuserver)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcGPUServer>> PostBcGpuserver(BcGPUServer bcGpuserver)
        {
            _context.BcGPUServer.Add(bcGpuserver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGpuserver", new { id = bcGpuserver.Id }, bcGpuserver);
        }

        // DELETE: api/BcGpuserver/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGPUServer>> DeleteBcGpuserver(long id)
        {
            var bcGpuserver = await _context.BcGPUServer.FindAsync(id);
            if (bcGpuserver == null)
            {
                return NotFound();
            }

            _context.BcGPUServer.Remove(bcGpuserver);
            await _context.SaveChangesAsync();

            return bcGpuserver;
        }

        private bool BcGpuserverExists(long id)
        {
            return _context.BcGPUServer.Any(e => e.Id == id);
        }
    }
}
