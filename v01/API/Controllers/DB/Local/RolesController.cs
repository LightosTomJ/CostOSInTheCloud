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
    public class RolesController : ControllerBase
    {
        private readonly LocalContext _context;

        public RolesController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoles(string id)
        {
            var roles = await _context.Roles.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(string id, Roles roles)
        {
            if (id != roles.Roleid)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Roles>> PostRoles(Roles roles)
        {
            _context.Roles.Add(roles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolesExists(roles.Roleid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoles", new { id = roles.Roleid }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Roles>> DeleteRoles(string id)
        {
            var roles = await _context.Roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();

            return roles;
        }

        private bool RolesExists(string id)
        {
            return _context.Roles.Any(e => e.Roleid == id);
        }
    }
}
