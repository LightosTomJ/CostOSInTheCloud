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
    public class GroupcodeController : ControllerBase
    {
        private readonly localContext _context;

        public GroupcodeController(localContext context)
        {
            _context = context;
        }

        // GET: api/Groupcode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groupcode>>> GetGroupcode()
        {
            return await _context.Groupcode.ToListAsync();
        }

        // GET: api/Groupcode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groupcode>> GetGroupcode(long id)
        {
            var groupcode = await _context.Groupcode.FindAsync(id);

            if (groupcode == null)
            {
                return NotFound();
            }

            return groupcode;
        }

        // PUT: api/Groupcode/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupcode(long id, Groupcode groupcode)
        {
            if (id != groupcode.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(groupcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupcodeExists(id))
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

        // POST: api/Groupcode
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Groupcode>> PostGroupcode(Groupcode groupcode)
        {
            _context.Groupcode.Add(groupcode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupcode", new { id = groupcode.Groupcodeid }, groupcode);
        }

        // DELETE: api/Groupcode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groupcode>> DeleteGroupcode(long id)
        {
            var groupcode = await _context.Groupcode.FindAsync(id);
            if (groupcode == null)
            {
                return NotFound();
            }

            _context.Groupcode.Remove(groupcode);
            await _context.SaveChangesAsync();

            return groupcode;
        }

        private bool GroupcodeExists(long id)
        {
            return _context.Groupcode.Any(e => e.Groupcodeid == id);
        }
    }
}
