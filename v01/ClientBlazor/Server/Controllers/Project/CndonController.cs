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
    public class CndonController : ControllerBase
    {
        private readonly projectContext _context;

        public CndonController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Cndon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cndon>>> GetCndon()
        {
            return await _context.Cndon.ToListAsync();
        }

        // GET: api/Cndon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cndon>> GetCndon(long id)
        {
            var cndon = await _context.Cndon.FindAsync(id);

            if (cndon == null)
            {
                return NotFound();
            }

            return cndon;
        }

        // PUT: api/Cndon/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCndon(long id, Cndon cndon)
        {
            if (id != cndon.Conditionid)
            {
                return BadRequest();
            }

            _context.Entry(cndon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CndonExists(id))
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

        // POST: api/Cndon
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cndon>> PostCndon(Cndon cndon)
        {
            _context.Cndon.Add(cndon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCndon", new { id = cndon.Conditionid }, cndon);
        }

        // DELETE: api/Cndon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cndon>> DeleteCndon(long id)
        {
            var cndon = await _context.Cndon.FindAsync(id);
            if (cndon == null)
            {
                return NotFound();
            }

            _context.Cndon.Remove(cndon);
            await _context.SaveChangesAsync();

            return cndon;
        }

        private bool CndonExists(long id)
        {
            return _context.Cndon.Any(e => e.Conditionid == id);
        }
    }
}
