using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Config;

namespace API.Controllers.DB.Config
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController : ControllerBase
    {
        private readonly configContext _context;

        public AspNetRolesController(configContext context)
        {
            _context = context;
        }

        // GET: api/AspNetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRoles>>> GetAspNetRoles()
        {
            return await _context.AspNetRoles.ToListAsync();
        }

        // GET: api/AspNetRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRoles>> GetAspNetRoles(string id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);

            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return aspNetRoles;
        }

        // PUT: api/AspNetRoles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoles(string id, AspNetRoles aspNetRoles)
        {
            if (id != aspNetRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRolesExists(id))
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

        // POST: api/AspNetRoles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AspNetRoles>> PostAspNetRoles(AspNetRoles aspNetRoles)
        {
            _context.AspNetRoles.Add(aspNetRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetRolesExists(aspNetRoles.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetRoles", new { id = aspNetRoles.Id }, aspNetRoles);
        }

        // DELETE: api/AspNetRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetRoles>> DeleteAspNetRoles(string id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            _context.AspNetRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();

            return aspNetRoles;
        }

        private bool AspNetRolesExists(string id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }
    }
}
