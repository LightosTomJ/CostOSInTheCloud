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
    public class ProjectuserController : ControllerBase
    {
        private readonly localContext _context;

        public ProjectuserController(localContext context)
        {
            _context = context;
        }

        // GET: api/Projectuser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectuser>>> GetProjectuser()
        {
            return await _context.Projectuser.ToListAsync();
        }

        // GET: api/Projectuser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectuser>> GetProjectuser(long id)
        {
            var projectuser = await _context.Projectuser.FindAsync(id);

            if (projectuser == null)
            {
                return NotFound();
            }

            return projectuser;
        }

        // PUT: api/Projectuser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectuser(long id, Projectuser projectuser)
        {
            if (id != projectuser.Puid)
            {
                return BadRequest();
            }

            _context.Entry(projectuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectuserExists(id))
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

        // POST: api/Projectuser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Projectuser>> PostProjectuser(Projectuser projectuser)
        {
            _context.Projectuser.Add(projectuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectuser", new { id = projectuser.Puid }, projectuser);
        }

        // DELETE: api/Projectuser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectuser>> DeleteProjectuser(long id)
        {
            var projectuser = await _context.Projectuser.FindAsync(id);
            if (projectuser == null)
            {
                return NotFound();
            }

            _context.Projectuser.Remove(projectuser);
            await _context.SaveChangesAsync();

            return projectuser;
        }

        private bool ProjectuserExists(long id)
        {
            return _context.Projectuser.Any(e => e.Puid == id);
        }
    }
}
