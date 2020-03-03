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
    public class ProjectusertemplateController : ControllerBase
    {
        private readonly localContext _context;

        public ProjectusertemplateController(localContext context)
        {
            _context = context;
        }

        // GET: api/Projectusertemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectusertemplate>>> GetProjectusertemplate()
        {
            return await _context.Projectusertemplate.ToListAsync();
        }

        // GET: api/Projectusertemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectusertemplate>> GetProjectusertemplate(long id)
        {
            var projectusertemplate = await _context.Projectusertemplate.FindAsync(id);

            if (projectusertemplate == null)
            {
                return NotFound();
            }

            return projectusertemplate;
        }

        // PUT: api/Projectusertemplate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectusertemplate(long id, Projectusertemplate projectusertemplate)
        {
            if (id != projectusertemplate.Templateid)
            {
                return BadRequest();
            }

            _context.Entry(projectusertemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectusertemplateExists(id))
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

        // POST: api/Projectusertemplate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Projectusertemplate>> PostProjectusertemplate(Projectusertemplate projectusertemplate)
        {
            _context.Projectusertemplate.Add(projectusertemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectusertemplate", new { id = projectusertemplate.Templateid }, projectusertemplate);
        }

        // DELETE: api/Projectusertemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectusertemplate>> DeleteProjectusertemplate(long id)
        {
            var projectusertemplate = await _context.Projectusertemplate.FindAsync(id);
            if (projectusertemplate == null)
            {
                return NotFound();
            }

            _context.Projectusertemplate.Remove(projectusertemplate);
            await _context.SaveChangesAsync();

            return projectusertemplate;
        }

        private bool ProjectusertemplateExists(long id)
        {
            return _context.Projectusertemplate.Any(e => e.Templateid == id);
        }
    }
}
