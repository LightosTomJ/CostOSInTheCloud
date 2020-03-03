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
    public class RawmaterialController : ControllerBase
    {
        private readonly projectContext _context;

        public RawmaterialController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Rawmaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rawmaterial>>> GetRawmaterial()
        {
            return await _context.Rawmaterial.ToListAsync();
        }

        // GET: api/Rawmaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rawmaterial>> GetRawmaterial(long id)
        {
            var rawmaterial = await _context.Rawmaterial.FindAsync(id);

            if (rawmaterial == null)
            {
                return NotFound();
            }

            return rawmaterial;
        }

        // PUT: api/Rawmaterial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRawmaterial(long id, Rawmaterial rawmaterial)
        {
            if (id != rawmaterial.Rawmatid)
            {
                return BadRequest();
            }

            _context.Entry(rawmaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RawmaterialExists(id))
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

        // POST: api/Rawmaterial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Rawmaterial>> PostRawmaterial(Rawmaterial rawmaterial)
        {
            _context.Rawmaterial.Add(rawmaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRawmaterial", new { id = rawmaterial.Rawmatid }, rawmaterial);
        }

        // DELETE: api/Rawmaterial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rawmaterial>> DeleteRawmaterial(long id)
        {
            var rawmaterial = await _context.Rawmaterial.FindAsync(id);
            if (rawmaterial == null)
            {
                return NotFound();
            }

            _context.Rawmaterial.Remove(rawmaterial);
            await _context.SaveChangesAsync();

            return rawmaterial;
        }

        private bool RawmaterialExists(long id)
        {
            return _context.Rawmaterial.Any(e => e.Rawmatid == id);
        }
    }
}
