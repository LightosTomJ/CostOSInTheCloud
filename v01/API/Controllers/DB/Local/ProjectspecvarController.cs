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
    public class ProjectspecvarController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectspecvarController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projectspecvar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectspecvar>>> GetProjectspecvar()
        {
            return await _context.Projectspecvar.ToListAsync();
        }

        // GET: api/Projectspecvar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectspecvar>> GetProjectspecvar(long id)
        {
            var projectspecvar = await _context.Projectspecvar.FindAsync(id);

            if (projectspecvar == null)
            {
                return NotFound();
            }

            return projectspecvar;
        }

        // PUT: api/Projectspecvar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectspecvar(long id, Projectspecvar projectspecvar)
        {
            if (id != projectspecvar.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectspecvar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectspecvarExists(id))
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

        // POST: api/Projectspecvar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Projectspecvar>> PostProjectspecvar(Projectspecvar projectspecvar)
        {
            _context.Projectspecvar.Add(projectspecvar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectspecvar", new { id = projectspecvar.Id }, projectspecvar);
        }

        // DELETE: api/Projectspecvar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectspecvar>> DeleteProjectspecvar(long id)
        {
            var projectspecvar = await _context.Projectspecvar.FindAsync(id);
            if (projectspecvar == null)
            {
                return NotFound();
            }

            _context.Projectspecvar.Remove(projectspecvar);
            await _context.SaveChangesAsync();

            return projectspecvar;
        }

        private bool ProjectspecvarExists(long id)
        {
            return _context.Projectspecvar.Any(e => e.Id == id);
        }
    }
}
