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
    public class ProjectinfoController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectinfoController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projectinfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectinfo>>> GetProjectinfo()
        {
            return await _context.Projectinfo.ToListAsync();
        }

        // GET: api/Projectinfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectinfo>> GetProjectinfo(long id)
        {
            var projectinfo = await _context.Projectinfo.FindAsync(id);

            if (projectinfo == null)
            {
                return NotFound();
            }

            return projectinfo;
        }

        // PUT: api/Projectinfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectinfo(long id, Projectinfo projectinfo)
        {
            if (id != projectinfo.Projectinfoid)
            {
                return BadRequest();
            }

            _context.Entry(projectinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectinfoExists(id))
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

        // POST: api/Projectinfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Projectinfo>> PostProjectinfo(Projectinfo projectinfo)
        {
            _context.Projectinfo.Add(projectinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectinfo", new { id = projectinfo.Projectinfoid }, projectinfo);
        }

        // DELETE: api/Projectinfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectinfo>> DeleteProjectinfo(long id)
        {
            var projectinfo = await _context.Projectinfo.FindAsync(id);
            if (projectinfo == null)
            {
                return NotFound();
            }

            _context.Projectinfo.Remove(projectinfo);
            await _context.SaveChangesAsync();

            return projectinfo;
        }

        private bool ProjectinfoExists(long id)
        {
            return _context.Projectinfo.Any(e => e.Projectinfoid == id);
        }
    }
}
