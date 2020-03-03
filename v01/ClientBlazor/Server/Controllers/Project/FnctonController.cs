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
    public class FnctonController : ControllerBase
    {
        private readonly projectContext _context;

        public FnctonController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Fncton
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fncton>>> GetFncton()
        {
            return await _context.Fncton.ToListAsync();
        }

        // GET: api/Fncton/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fncton>> GetFncton(long id)
        {
            var fncton = await _context.Fncton.FindAsync(id);

            if (fncton == null)
            {
                return NotFound();
            }

            return fncton;
        }

        // PUT: api/Fncton/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFncton(long id, Fncton fncton)
        {
            if (id != fncton.Functionid)
            {
                return BadRequest();
            }

            _context.Entry(fncton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FnctonExists(id))
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

        // POST: api/Fncton
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Fncton>> PostFncton(Fncton fncton)
        {
            _context.Fncton.Add(fncton);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFncton", new { id = fncton.Functionid }, fncton);
        }

        // DELETE: api/Fncton/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fncton>> DeleteFncton(long id)
        {
            var fncton = await _context.Fncton.FindAsync(id);
            if (fncton == null)
            {
                return NotFound();
            }

            _context.Fncton.Remove(fncton);
            await _context.SaveChangesAsync();

            return fncton;
        }

        private bool FnctonExists(long id)
        {
            return _context.Fncton.Any(e => e.Functionid == id);
        }
    }
}
