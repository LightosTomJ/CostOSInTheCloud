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
    public class AlcUserGroupsController : ControllerBase
    {
        private readonly localContext _context;

        public AlcUserGroupsController(localContext context)
        {
            _context = context;
        }

        // GET: api/AlcUserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcUserGroups>>> GetAlcUserGroups()
        {
            return await _context.AlcUserGroups.ToListAsync();
        }

        // GET: api/AlcUserGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcUserGroups>> GetAlcUserGroups(Guid id)
        {
            var alcUserGroups = await _context.AlcUserGroups.FindAsync(id);

            if (alcUserGroups == null)
            {
                return NotFound();
            }

            return alcUserGroups;
        }

        // PUT: api/AlcUserGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcUserGroups(Guid id, AlcUserGroups alcUserGroups)
        {
            if (id != alcUserGroups.UserId)
            {
                return BadRequest();
            }

            _context.Entry(alcUserGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcUserGroupsExists(id))
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

        // POST: api/AlcUserGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcUserGroups>> PostAlcUserGroups(AlcUserGroups alcUserGroups)
        {
            _context.AlcUserGroups.Add(alcUserGroups);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcUserGroupsExists(alcUserGroups.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcUserGroups", new { id = alcUserGroups.UserId }, alcUserGroups);
        }

        // DELETE: api/AlcUserGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcUserGroups>> DeleteAlcUserGroups(Guid id)
        {
            var alcUserGroups = await _context.AlcUserGroups.FindAsync(id);
            if (alcUserGroups == null)
            {
                return NotFound();
            }

            _context.AlcUserGroups.Remove(alcUserGroups);
            await _context.SaveChangesAsync();

            return alcUserGroups;
        }

        private bool AlcUserGroupsExists(Guid id)
        {
            return _context.AlcUserGroups.Any(e => e.UserId == id);
        }
    }
}
