using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class Extracode2Controller : ControllerBase
    {
        private readonly projectContext _context;

        public Extracode2Controller(projectContext context)
        {
            _context = context;
        }

        // GET: api/Extracode2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode2>>> GetExtracode2()
        {
            return await _context.Extracode2.ToListAsync();
        }

        // GET: api/Extracode2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode2>> GetExtracode2(long id)
        {
            var extracode2 = await _context.Extracode2.FindAsync(id);

            if (extracode2 == null)
            {
                return NotFound();
            }

            return extracode2;
        }

        // PUT: api/Extracode2/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode2(long id, Extracode2 extracode2)
        {
            if (id != extracode2.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode2Exists(id))
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

        // POST: api/Extracode2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Extracode2>> PostExtracode2(Extracode2 extracode2)
        {
            _context.Extracode2.Add(extracode2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode2", new { id = extracode2.Groupcodeid }, extracode2);
        }

        // DELETE: api/Extracode2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode2>> DeleteExtracode2(long id)
        {
            var extracode2 = await _context.Extracode2.FindAsync(id);
            if (extracode2 == null)
            {
                return NotFound();
            }

            _context.Extracode2.Remove(extracode2);
            await _context.SaveChangesAsync();

            return extracode2;
        }

        private bool Extracode2Exists(long id)
        {
            return _context.Extracode2.Any(e => e.Groupcodeid == id);
        }
    }
}
