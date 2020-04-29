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
    public class ProjecturlController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjecturlController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projecturl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectURL>>> GetProjecturl()
        {
            return await _context.Projecturl.ToListAsync();
        }

        // GET: api/Projecturl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectURL>> GetProjecturl(long id)
        {
            var projecturl = await _context.Projecturl.FindAsync(id);

            if (projecturl == null)
            {
                return NotFound();
            }

            return projecturl;
        }

        // PUT: api/Projecturl/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjecturl(long id, ProjectURL projecturl)
        {
            if (id != projecturl.Projecturlid)
            {
                return BadRequest();
            }

            _context.Entry(projecturl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjecturlExists(id))
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

        // POST: api/Projecturl
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectURL>> PostProjecturl(ProjectURL projecturl)
        {
            _context.Projecturl.Add(projecturl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjecturl", new { id = projecturl.Projecturlid }, projecturl);
        }

        // DELETE: api/Projecturl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectURL>> DeleteProjecturl(long id)
        {
            var projecturl = await _context.Projecturl.FindAsync(id);
            if (projecturl == null)
            {
                return NotFound();
            }

            _context.Projecturl.Remove(projecturl);
            await _context.SaveChangesAsync();

            return projecturl;
        }

        private bool ProjecturlExists(long id)
        {
            return _context.Projecturl.Any(e => e.Projecturlid == id);
        }
    }
}
