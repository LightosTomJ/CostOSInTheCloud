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
    public class Extracode1Controller : ControllerBase
    {
        private readonly projectContext _context;

        public Extracode1Controller(projectContext context)
        {
            _context = context;
        }

        // GET: api/Extracode1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extracode1>>> GetExtracode1()
        {
            return await _context.Extracode1.ToListAsync();
        }

        // GET: api/Extracode1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extracode1>> GetExtracode1(long id)
        {
            var extracode1 = await _context.Extracode1.FindAsync(id);

            if (extracode1 == null)
            {
                return NotFound();
            }

            return extracode1;
        }

        // PUT: api/Extracode1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtracode1(long id, Extracode1 extracode1)
        {
            if (id != extracode1.Groupcodeid)
            {
                return BadRequest();
            }

            _context.Entry(extracode1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Extracode1Exists(id))
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

        // POST: api/Extracode1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Extracode1>> PostExtracode1(Extracode1 extracode1)
        {
            _context.Extracode1.Add(extracode1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtracode1", new { id = extracode1.Groupcodeid }, extracode1);
        }

        // DELETE: api/Extracode1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extracode1>> DeleteExtracode1(long id)
        {
            var extracode1 = await _context.Extracode1.FindAsync(id);
            if (extracode1 == null)
            {
                return NotFound();
            }

            _context.Extracode1.Remove(extracode1);
            await _context.SaveChangesAsync();

            return extracode1;
        }

        private bool Extracode1Exists(long id)
        {
            return _context.Extracode1.Any(e => e.Groupcodeid == id);
        }
    }
}
